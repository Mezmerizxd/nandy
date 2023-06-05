#include <stdio.h>
#include <string.h>
#include <stdlib.h>

#include "bsp/board.h"
#include "hardware/vreg.h"
#include "hardware/clocks.h"
#include "pico/stdlib.h"
#include "pico/bootrom.h"

#include "tusb.h"

#include "xbox/xbox.hpp"

#define LED_PIN 25

// Commands
#define GET_VERSION 0x00
#define GET_STATUS 0x01

#pragma pack(push, 1)
struct Command
{
    uint8_t command;
    uint32_t lba;
};
#pragma pack(pop)

void led_blink(void)
{
    static uint32_t start_ms = 0;
    static bool led_state = false;

    uint32_t now = board_millis();

    if (now - start_ms < 50)
        return;

    start_ms = now;

    gpio_put(LED_PIN, led_state);
    led_state = 1 - led_state;
}

void tud_mount_cb(void)
{
}

void tud_umount_cb(void)
{
}

void tud_suspend_cb(bool remote_wakeup_en)
{
    (void)remote_wakeup_en;
}

void tud_resume_cb(void)
{
}

void tud_cdc_rx_cb(uint8_t itf)
{
    (void)itf;
    led_blink();

    uint32_t avilable_data = tud_cdc_available();

    if (avilable_data < sizeof(Command))
        return;

    Command cmd;

    tud_cdc_read(&cmd, sizeof(Command));

    switch (cmd.command)
    {
    case GET_VERSION:
        tud_cdc_write("Flasher v0.1", 12);
        break;
    case GET_STATUS:
        tud_cdc_write("Status: OK", 10);
        break;
    }

    tud_cdc_write_flush();
}

void tud_cdc_tx_complete_cb(uint8_t itf)
{
    (void)itf;
}

int main()
{
    using namespace NandyFlasher;

    vreg_set_voltage(VREG_VOLTAGE_1_30);
    set_sys_clock_khz(266000, true);

    uint32_t freq = clock_get_hz(clk_sys);
    clock_configure(clk_peri, 0, CLOCKS_CLK_PERI_CTRL_AUXSRC_VALUE_CLK_SYS, freq, freq);

    stdio_init_all();

    gpio_init(LED_PIN);
    gpio_set_dir(LED_PIN, GPIO_OUT);

    tusb_init();

    g_xbox.Init();

    int runtime = 0;
    while (1)
    {
        tud_task();
        printf("Runtime: %d\n", runtime++);
    }
}