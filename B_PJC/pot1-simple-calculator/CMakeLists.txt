cmake_minimum_required(VERSION 3.8)
project(pot1-simple-calculator)

set(CMAKE_C_STANDARD 99)

set(SOURCE_FILES pot1.c)
add_executable(pot1-simple-calculator ${SOURCE_FILES})