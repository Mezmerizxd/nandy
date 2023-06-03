#!/bin/bash

windows() {
  cmake ./Flasher -B./build/Flasher -G "MinGW Makefiles"
  mingw32-make -j4 -C ./build/Flasher
  return
};

linux() {
  cmake ./Flasher -B./build/Flasher
  make -j4 -C ./build/Flasher
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