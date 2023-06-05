#!/bin/bash

windows() {
  cmake ./Flasher -B./build/flasher -G "MinGW Makefiles"
  mingw32-make -j4 -C ./build/flasher
  return
};

linux() {
  cmake ./Flasher -B./build/flasher
  make -j4 -C ./build/flasher
  return
};

case "$(uname -s)" in

   Linux)
      echo "System is compatible, proceeding with build..."
      linux
     ;;

   Darwin)
      echo "MacOS not supported yet."
      exit 1
     ;;

   CYGWIN*|MINGW32*|MINGW64*|MSYS*)
      echo "System is compatible, proceeding with build..."
      windows
     ;;
esac