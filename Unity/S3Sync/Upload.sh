#!/bin/sh
PUBLISHDIR=$(dirname "$0")

#echo $PUBLISHDIR
aws s3 sync $PUBLISHDIR/Upload/ s3://my-resturant-empire/public/game_res/assetbundle/$1 --acl public-read --exclude "*.manifest"  --exclude "*.meta" --exclude "*.DS_Store"
aws cloudfront create-invalidation --distribution-id E2CBN7SK6U7058 --paths "/public/game_res/assetbundle/$1/*"