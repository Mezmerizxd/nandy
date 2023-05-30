#include <stdint.h>
#include <stdio.h>

namespace NandyFlasher
{
  class Xbox
  {
  public:
    void Init();

    uint32_t GetFlashConfig();

    int ReadNandBlock(uint32_t block, uint8_t *buffer, uint8_t *spare);
    int EraseNandBlock(uint32_t block);
    int WriteNandBlock(uint32_t block, uint8_t *buffer, uint8_t *spare);
  };

  inline Xbox g_xbox;
}