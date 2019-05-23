# my-project

> A Mpvue project

## Build Setup


# 开发时构建
npm run dev

# 打包构建
npm run build

# 指定平台的开发时构建(微信、百度、头条、支付宝)
npm run dev:wx
npm run dev:swan
npm run dev:tt
npm run dev:my

# 指定平台的打包构建
npm run build:wx
npm run build:swan
npm run build:tt
npm run build:my

// 调用API从本地缓存中获取数据
/*
* 平台 api 差异的处理方式:  api 方法统一挂载到 mpvue 名称空间, 平台判断通过 mpvuePlatform 特征字符串
* 微信：mpvue === wx, mpvuePlatform === 'wx'
* 头条：mpvue === tt, mpvuePlatform === 'tt'
* 百度：mpvue === swan, mpvuePlatform === 'swan'
* 支付宝(蚂蚁)：mpvue === my, mpvuePlatform === 'my'
*/