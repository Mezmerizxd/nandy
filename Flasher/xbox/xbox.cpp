#include "../common.hpp"

namespace NandyFlasher
{
  void Xbox::Initialize()
  {
    printf("Xbox initialized.\n");
  }

  uint32_t Xbox::GetFlashConfig()
  {
    return 0;
  }

  int Xbox::ReadNandBlock(uint32_t block, uint8_t *buffer, uint8_t *spare)
  {
    return 0;
  }

  int Xbox::EraseNandBlock(uint32_t block)
  {
    return 0;
  }

  int Xbox::WriteNandBlock(uint32_t block, uint8_t *buffer, uint8_t *spare)
  {
    return 0;
  }
}