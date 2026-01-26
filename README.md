# Windows Unattended Generator Web

一个基于 Web 的 Windows 无人值守安装文件 (autounattend.xml) 生成器。

![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4)
![Blazor](https://img.shields.io/badge/Blazor-Server-purple)
![Docker](https://img.shields.io/badge/Docker-Ready-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)

## ✨ 功能特性

- 🎯 **可视化配置** - 通过友好的 Web 界面配置所有无人值守安装选项
- 💿 **Windows 版本** - 支持选择预设版本或自定义产品密钥
- 🌐 **区域和语言** - 配置系统语言、键盘布局和地理位置
- 👤 **用户账户** - 创建本地管理员账户，支持自动登录
- 💾 **磁盘分区** - GPT/MBR 自动分区或自定义脚本
- 🎨 **个性化设置** - 主题颜色、壁纸、开始菜单布局
- ⚡ **系统优化** - 禁用遥测、优化隐私设置
- 🗑️ **预装软件删除** - 移除 Windows 预装应用
- 🔐 **安全设置** - WDAC、账户锁定策略等
- 📜 **自定义脚本** - 在安装各阶段执行自定义 PowerShell 脚本

## 🚀 快速开始

### 使用 Docker（推荐）

```bash
# 使用 Docker Compose
docker compose up -d

# 或直接使用 Docker
docker run -d -p 8080:8080 --name unattended-generator unattended-generator-web
```

访问 http://localhost:8080 开始使用。

### 本地开发

确保已安装 [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)。

```bash
# 克隆仓库
git clone https://github.com/your-username/unattended-generator-web.git
cd unattended-generator-web

# 运行项目
dotnet run

# 或在开发模式下运行
dotnet watch run
```

## 🐳 Docker 部署

### 构建镜像

```bash
docker build -t unattended-generator-web .
```

### 运行容器

```bash
docker run -d \
  --name unattended-generator \
  -p 8080:8080 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  unattended-generator-web
```

### 使用 Docker Compose

```bash
docker compose up -d
```

## 🔧 配置

| 环境变量 | 默认值 | 描述 |
|---------|--------|------|
| `ASPNETCORE_ENVIRONMENT` | `Production` | 运行环境 |
| `ASPNETCORE_URLS` | `http://+:8080` | 监听地址 |

## 📁 项目结构

```
unattended-generator-web/
├── Components/
│   ├── Layout/           # 布局组件
│   ├── Pages/            # 页面组件
│   │   └── Sections/     # 配置区块
│   └── Shared/           # 共享组件
├── Library/
│   └── UnattendGenerator/ # XML 生成核心库
├── Services/             # 业务服务
├── wwwroot/              # 静态资源
├── Dockerfile            # Docker 构建文件
└── compose.yaml          # Docker Compose 配置
```

## 🛠️ 技术栈

- **框架**: ASP.NET Core 9.0 + Blazor Server
- **UI**: 自定义 CSS 深色主题
- **核心库**: UnattendGenerator（基于 [schneegans-de/unattend-generator](https://github.com/schneegans-de/unattend-generator)）

## 📝 使用方式

1. 在左侧导航栏选择要配置的选项类别
2. 根据需要调整各项设置
3. 点击右上角「预览 XML」查看生成的配置
4. 点击「生成 XML」下载 `autounattend.xml` 文件
5. 将文件放入 Windows 安装 U 盘根目录即可实现无人值守安装

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！

## 📄 许可证

本项目基于 MIT 许可证开源。

## 致谢

- [schneegans-de/unattend-generator](https://github.com/schneegans-de/unattend-generator) - 核心 XML 生成库
