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
        led_blink();
    }
}