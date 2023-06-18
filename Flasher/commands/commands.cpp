#include "../common.hpp"

namespace NandyFlasher
{
  void Commands::Initialize()
  {
    printf("Xbox initialized.\n");
  }

  void Commands::Update(Command cmd)
  {
    switch (cmd.command)
    {
    case GET_VERSION:
    {
      tud_cdc_write(&g_core.Version, sizeof(g_core.Version));
      tud_cdc_write_flush();
      break;
    }
    case TOGGLE_PICO_BLINKING:
    {
      g_core.IsPicoBlinking = !g_core.IsPicoBlinking;

      // tud_cdc_write(&g_core.IsPicoBlinking, sizeof(g_core.IsPicoBlinking));
      tud_cdc_write_flush();
      break;
    }
    }
  }
}