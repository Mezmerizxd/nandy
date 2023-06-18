#include "../common.hpp"

void led_blink(void)
{
  static uint32_t start_ms = 0;
  static bool led_state = false;

  uint32_t now = board_millis();

  if (now - start_ms < 50)
    return;

  start_ms = now;

  gpio_put(25, led_state);
  led_state = 1 - led_state;
}

namespace NandyFlasher
{
  void Core::Initialize()
  {
    printf("Core initialized.\n");

    vreg_set_voltage(VREG_VOLTAGE_1_30);
    set_sys_clock_khz(266000, true);

    uint32_t freq = clock_get_hz(clk_sys);
    clock_configure(clk_peri, 0, CLOCKS_CLK_PERI_CTRL_AUXSRC_VALUE_CLK_SYS, freq, freq);

    stdio_init_all();

    gpio_init(25);
    gpio_set_dir(25, GPIO_OUT);

    tusb_init();
  }

  void Core::Update()
  {
    tud_task();

    if (IsPicoBlinking)
      led_blink();
  }
}