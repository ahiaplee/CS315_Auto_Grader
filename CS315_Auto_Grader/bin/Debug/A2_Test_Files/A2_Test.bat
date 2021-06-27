@echo off
DEL main.exe
call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\vcvars64.bat"
cl main.cpp bmp.cpp /O2 /nologo /D _WIN32 /EHsc
main.exe 0 0

@echo on
diff chessboard_user.bmp chessboard_basic.bmp
diff jaguar_user.bmp jaguar_basic.bmp
diff mandrill_user.bmp mandrill_basic.bmp
diff mandrill_odd_user.bmp mandrill_odd_basic.bmp

@echo off
DEL jaguar_user.bmp
DEL jaguar_basic.bmp
DEL mandrill_user.bmp
DEL mandrill_basic.bmp
DEL mandrill_odd_user.bmp
DEL mandrill_odd_basic.bmp
DEL chessboard_user.bmp
DEL chessboard_basic.bmp 