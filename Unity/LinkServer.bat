@echo off
set SyncPath=Assets\Scripts\Module\ServerComponent
set LinkPath=../ExperimentalNetwork
for %%i in (%LinkPath%/FrontEndMessage/Outer/*) do (
    call :Sync "%SyncPath%\Proto\Message\%%i" "%LinkPath%/FrontEndMessage/Outer/%%i"
)
for %%i in (%LinkPath%/ClientCore/DotNetty/*) do (
    call :Sync "%SyncPath%\ThirdPlugins\DotNetty\%%i" "%LinkPath%/ClientCore/DotNetty/%%i"
)
call :treeProcess %SyncPath%\ThirdPlugins\MessagePack\ %LinkPath%/ClientCore/MessagePack/
call :Sync "%SyncPath%\Proto\Interface\IRequest.cs" "%LinkPath%/FrontEndMessage/Interface/IRequest.cs"
call :Sync "%SyncPath%\Proto\Interface\IResponse.cs" "%LinkPath%/FrontEndMessage/Interface/IResponse.cs"
call :Sync "%SyncPath%\Attribute\ProtoCode.cs" "%LinkPath%/FrontEndMessage/Attribute/ProtoCode.cs"
call :Sync "%SyncPath%\Proto\ErrorCode.cs" "%LinkPath%/FrontEndMessage/ErrorCode.cs"
call :Sync "%SyncPath%\Component\MessageDispatcherComponent.cs" "%LinkPath%/Server.Model/Module/FrontEndServer/MessageDispatcherComponent.cs"
call :Sync "%SyncPath%\Component\IProtoHandler.cs" "%LinkPath%/Server.Model/Module/FrontEndServer/IProtoHandler.cs"
call :Sync "%SyncPath%\Component\MessageInfo.cs" "%LinkPath%/Server.Model/Module/FrontEndServer/MessageInfo.cs"
call :Sync "%SyncPath%\Client\ClientHandler.cs" "%LinkPath%/ClientCore/ClientHandler.cs"
call :Sync "%SyncPath%\Client\NetClient.cs" "%LinkPath%/ClientCore/NetClient.cs"
call :Sync "%SyncPath%\Client\ProtoCodeManager.cs" "%LinkPath%/ClientCore/ProtoCodeManager.cs"
call :Sync "%SyncPath%\Server.Model\Module\FrontEndServer\ProtoHandler.cs" "%LinkPath%/ClientCore/ProtoHandler.cs"
call :Sync "%SyncPath%\Proto\StateCode.cs" "%LinkPath%/ClientServer.Grains/StateCode.cs"

:Sync
    rem echo "%~1"  "%~2"
    if "%~1"=="" goto:eof
    if not exist "%~dp1" mkdir "%~dp1"
    if not exist "%~1" mklink /H "%~1" "%~2"
    
goto:eof

:treeProcess
call :strlen %~dp2 len
setlocal EnableDelayedExpansion
for /R %LinkPath%/ClientCore/MessagePack %%i in (*) do (
set x=%%i
call :Sync "%SyncPath%\ThirdPlugins\MessagePack\!x:~%len%!" "%LinkPath%/ClientCore/MessagePack/!x:~%len%!"
)
goto:eof

:strlen string len
SetLocal EnableDelayedExpansion
set "token=#%~1" & set "len=0"
for /L %%A in (12,-1,0) do (
    set/A "len|=1<<%%A"
    for %%B in (!len!) do if "!token:~%%B,1!"=="" set/A "len&=~1<<%%A"
)
EndLocal & set %~2=%len%
exit/B