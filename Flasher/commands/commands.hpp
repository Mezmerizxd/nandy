namespace NandyFlasher
{
  enum Cmd
  {
    GET_VERSION = 0x00,
    TOGGLE_PICO_BLINKING = 0x01,
  };

#pragma pack(push, 1)
  struct Command
  {
    uint8_t command;
    uint32_t lba;
  };
#pragma pack(pop)

  class Commands
  {
  public:
    void Initialize();

    void Update(Command cmd);
  };

  inline Commands g_commands;
}