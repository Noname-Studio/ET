@echo off
SetLocal
set version=%~1
aws s3 sync %~dp0Upload\ s3://my-resturant-empire/public/game_res/assetbundle/%version% --acl public-read --exclude "*.manifest"  --exclude "*.meta"
aws cloudfront create-invalidation --distribution-id E2CBN7SK6U7058 --paths "/public/game_res/assetbundle/%version%/*"