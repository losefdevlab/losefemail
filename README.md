# LosefEmail

> Copyright (c) 2025 LosefDevLab
> Copyright (c) 2025 kkko Chat Community Studio
>
> 以上两个组织统称为LosefEmail开发团队.
>
> LosefEmail (2025-Now) by LosefEmail开发团队 freedom-create on community"KKKO CHAT COMMUNITY; CHAT TECHNOLOGY COMMUNITY" in XFCSTD2
>
> XFCSTD2.md路径:./XFCSTD2.md

各位好啊!🎉LosefDevLab在2025年5月17日正式建立Repo，启用新项目，开发这个新的项目。

LosefEmail是由我们的团队完全自己设计的LosefEMS邮件系统核心（别问为什么不用现有的轮子，那已经有了其他的轮子我用这个轮子也没多大意义），它本质上还是一种特殊形式的LosefChat，只不过现在你可以用这个东西进行收发邮件！

## License

LosefEmail使用MIT许可证。

## 介绍&原理

LosefEmail是一个自由的邮件系统，这就意味着你可以在里面不受限制的注册邮箱账号，虽然我们无法控制，但我们10分不建议您对邮箱的注册进行限制，这也就是为什么我们并没有添加什么白名单系统，究其原因，第一是白名单在技术上不易开发和控制，第二是这并不自由。

LosefEmail还使用了IRC，就意味着他其实是一个聊天，只不过特殊点。

邮箱系统使用了我们自个设计的LosefIREMS，流程如下：

```
+-------------------+            +---------------------+
|                   |            |                     |
|  IRC Client (User)|            |   LosefEmail Server |
|                   |            |                     |
+-------------------+            +----------+----------+
         |                                 |
         | (em, clientInfo)                |
         |---------------------------------|
         |                                 |
         |                                 | 1. Receive send email request
         |                                 |    - Parse email content (em)
         |                                 |    - Extract client info
         |                                 |
         |                                 | 2. Forward to IRC server
         |                                 |    - IRC.Sendmessage(em,clientInfo)
         |                                 |
         |                                 |
         | (Send message via IRC)          |
         |<================================|
         |                                 |
         |                                 |
         | (Response from IRC server)      |
         |<--------------------------------|
         |                                 |
         |                                 |
         v                                 v

+------------------+             +--------------------+
|                  |             |                    |
|   IRC Server     |             |   IRC Client B     |
|                  |             |   (Recipient)      |
+------------------+             +--------------------+
        |                                  |
        | (em, clientInfo)                 |
        |----------------------------------|
        |                                  |
        |                                  | 1. Receive forwarded message
        |                                  | 2. Deliver to userB's client
        |                                  |
        |                                  |
        v                                  v






+-------------------+            +---------------------+
|                   |            |                     |
|  IRC Client (User)|            |   LosefEmail Server |
|                   |            |                     |
+-------------------+            +----------+----------+
         |                                 |
         | (wantreg acc)                   |
         |---------------------------------|
         |                                 |
         |                                 | 1. Receive registration request
         |                                 |    - Parse request for new account
         |                                 |
         |                                 | 2. Validate and process registration
         |                                 |    - Check username/email availability
         |                                 |    - Generate credentials
         |                                 |
         |                                 |
         | (accept and reg acc)            |
         |<================================|
         |                                 |
         |                                 |
         v                                 v

+------------------+             +--------------------+
|                  |             |                    |
|   IRC Server     |             |   New IRC Client   |
|                  |             |   (New User)       |
+------------------+             +--------------------+
        |                                  |
        | (new user registered:           |
        |  kkko@losefem:new)              |
        |---------------------------------|
        |                                  |
        |                                  | 1. Notify IRC server of new user
        |                                  | 2. Setup initial configurations
        |                                  |
        |                                  |
        v                                  v
```

那么，我们如何表示一个用户?

与常规邮箱地址不同的是,   我们使用以下格式:

<邮箱服务器运营组织>@<邮箱系统>:<用户名称>

例如:kkko@losefem:along

然而，我们怎么编辑邮箱?

不会有人不会用vim吧...

[download : vim online](https://www.vim.org/download.php#pc) <- 点击可以下载vim,  我们使用vim来作为中介编辑器，以保持纯命令行

[Linux vi/vim 教学文档 | 菜教高级人民计算机学院、菜教高级人民计算机网络教育出版社官网（bushi](https://www.runoob.com/linux/linux-vim.html) <- vim教程,  没用过vim的欢迎来用这种远古级别但又10分好用的编辑器，欢迎加入vim社区！

## 使用教程文档

[losefemail使用教程 | LDL "How to use it" Docm](https://losefdevlab.gitbook.io/htu-losefem) <- LDL How to use it 专栏文档
