namespace NandyFlasher
{
  class Core
  {
  public:
    uint32_t Version = 0x00000001;
    bool IsPicoBlinking = false;

  public:
    void Initialize();

    void Update();
  };

  inline Core g_core;
}