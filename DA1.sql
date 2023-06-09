USE [QLBH_hotenSV]
GO
/****** Object:  Table [dbo].[ChitietDHB]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChitietDHB](
	[DonhangbanID] [char](10) NOT NULL,
	[MathangID] [char](10) NOT NULL,
	[Slban] [tinyint] NOT NULL,
	[DGban] [float] NOT NULL,
 CONSTRAINT [PK_ChitietDHB] PRIMARY KEY CLUSTERED 
(
	[DonhangbanID] ASC,
	[MathangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChitietDHN]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChitietDHN](
	[DonhangnhapID] [char](10) NOT NULL,
	[MathangID] [char](10) NOT NULL,
	[Slnhap] [tinyint] NOT NULL,
	[DGnhap] [float] NOT NULL,
 CONSTRAINT [PK_ChitietDHN] PRIMARY KEY CLUSTERED 
(
	[DonhangnhapID] ASC,
	[MathangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donhangban]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donhangban](
	[DonhangbanID] [char](10) NOT NULL,
	[NhanvienID] [char](10) NOT NULL,
	[KhachhangID] [char](10) NOT NULL,
	[Ngayban] [datetime] NOT NULL,
	[Trietkhauban] [float] NOT NULL,
 CONSTRAINT [PK_Donhangban] PRIMARY KEY CLUSTERED 
(
	[DonhangbanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donhangnhap]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donhangnhap](
	[Donhangnhap] [char](10) NOT NULL,
	[NhanvienID] [char](10) NOT NULL,
	[NhaCCID] [char](10) NOT NULL,
	[Ngaynhap] [datetime] NOT NULL,
	[Trietkhaunhap] [float] NOT NULL,
 CONSTRAINT [PK_Donhangnhap] PRIMARY KEY CLUSTERED 
(
	[Donhangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KhachHangID] [char](10) NOT NULL,
	[HotenKH] [nvarchar](30) NOT NULL,
	[DiachiKH] [nvarchar](50) NOT NULL,
	[EmailKH] [char](30) NOT NULL,
	[SdtKH] [char](11) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[loaihangID] [char](10) NOT NULL,
	[TenLH] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_LoaiHang] PRIMARY KEY CLUSTERED 
(
	[loaihangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatHang]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHang](
	[LoaiHangID] [char](10) NOT NULL,
	[MathangID] [char](10) NOT NULL,
	[Tenhang] [nvarchar](50) NOT NULL,
	[SoLuong] [nvarchar](10) NOT NULL,
	[DonGia] [int] NOT NULL,
 CONSTRAINT [PK_MatHang] PRIMARY KEY CLUSTERED 
(
	[MathangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACC]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACC](
	[NhaCCID] [char](10) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[diachiNCC] [nvarchar](50) NOT NULL,
	[SdtNCC] [char](11) NOT NULL,
 CONSTRAINT [PK_NHACC] PRIMARY KEY CLUSTERED 
(
	[NhaCCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[NhanVienID] [char](10) NOT NULL,
	[HotenNV] [nvarchar](30) NOT NULL,
	[GioitinhNV] [nvarchar](50) NOT NULL,
	[NgaysinhNV] [date] NOT NULL,
	[diachiNV] [nvarchar](50) NOT NULL,
	[EmailNV] [char](30) NOT NULL,
	[SdtNV] [char](11) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[NhanVienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/30/2023 6:42:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TK] [nvarchar](50) NOT NULL,
	[MK] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB001    ', N'XE001     ', 8, 5000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB002    ', N'XE002     ', 7, 600000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB003    ', N'XE003     ', 9, 7000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB004    ', N'XE004     ', 11, 8000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB005    ', N'XE005     ', 15, 9000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB006    ', N'XE006     ', 6, 10000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB007    ', N'XE007     ', 4, 11000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB008    ', N'XE008     ', 3, 12000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB009    ', N'XE009     ', 10, 13000000)
INSERT [dbo].[ChitietDHB] ([DonhangbanID], [MathangID], [Slban], [DGban]) VALUES (N'DHB010    ', N'XE010     ', 13, 14000000)
GO
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH001     ', N'XE001     ', 8, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH002     ', N'XE002     ', 7, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH003     ', N'XE003     ', 9, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH004     ', N'XE004     ', 11, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH005     ', N'XE001     ', 15, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH006     ', N'XE003     ', 6, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH007     ', N'XE002     ', 4, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH008     ', N'XE004     ', 3, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH009     ', N'XE003     ', 10, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH010     ', N'XE001     ', 13, 5000000)
INSERT [dbo].[ChitietDHN] ([DonhangnhapID], [MathangID], [Slnhap], [DGnhap]) VALUES (N'DH011     ', N'XE006     ', 7, 5000000)
GO
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB001    ', N'NV001     ', N'KH001     ', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 0.1)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB002    ', N'NV002     ', N'KH002     ', CAST(N'2023-05-26T00:00:00.000' AS DateTime), 0.05)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB003    ', N'NV003     ', N'KH003     ', CAST(N'2023-05-27T00:00:00.000' AS DateTime), 0.08)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB004    ', N'NV004     ', N'KH004     ', CAST(N'2023-05-28T00:00:00.000' AS DateTime), 0.12)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB005    ', N'NV001     ', N'KH005     ', CAST(N'2023-05-29T00:00:00.000' AS DateTime), 0.15)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB006    ', N'NV003     ', N'KH006     ', CAST(N'2023-05-30T00:00:00.000' AS DateTime), 0.03)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB007    ', N'NV002     ', N'KH007     ', CAST(N'2023-06-01T00:00:00.000' AS DateTime), 0.07)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB008    ', N'NV004     ', N'KH008     ', CAST(N'2023-06-02T00:00:00.000' AS DateTime), 0.09)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB009    ', N'NV003     ', N'KH009     ', CAST(N'2023-06-03T00:00:00.000' AS DateTime), 0.06)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB010    ', N'NV001     ', N'KH009     ', CAST(N'2023-06-04T00:00:00.000' AS DateTime), 0.11)
INSERT [dbo].[Donhangban] ([DonhangbanID], [NhanvienID], [KhachhangID], [Ngayban], [Trietkhauban]) VALUES (N'DHB011    ', N'NV005     ', N'KH005     ', CAST(N'2023-05-28T00:00:00.000' AS DateTime), 0.2)
GO
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH001     ', N'NV001     ', N'NCC001    ', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH002     ', N'NV002     ', N'NCC002    ', CAST(N'2023-05-26T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH003     ', N'NV003     ', N'NCC003    ', CAST(N'2023-05-27T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH004     ', N'NV004     ', N'NCC001    ', CAST(N'2023-05-28T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH005     ', N'NV001     ', N'NCC002    ', CAST(N'2023-05-29T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH006     ', N'NV003     ', N'NCC003    ', CAST(N'2023-05-30T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH007     ', N'NV002     ', N'NCC001    ', CAST(N'2023-06-01T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH008     ', N'NV004     ', N'NCC002    ', CAST(N'2023-06-02T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH009     ', N'NV003     ', N'NCC003    ', CAST(N'2023-06-03T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH010     ', N'NV001     ', N'NCC001    ', CAST(N'2023-06-04T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Donhangnhap] ([Donhangnhap], [NhanvienID], [NhaCCID], [Ngaynhap], [Trietkhaunhap]) VALUES (N'DH011     ', N'NV004     ', N'NCC006    ', CAST(N'2023-05-30T00:00:00.000' AS DateTime), 5)
GO
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH001     ', N'Nguyễn Văn A', N'123 Đường ABC, Q.1, TP.HCM', N'nguyenvana@gmail.com          ', N'0901234567 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH002     ', N'Trần Thị B', N'456 Đường XYZ, Q.2, TP.HCM', N'tranthib@gmail.com            ', N'0902345678 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH003     ', N'Lê Văn C', N'789 Đường KLM, Q.3, TP.HCM', N'levanc@gmail.com              ', N'0903456789 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH004     ', N'Phạm Thị D', N'101 Đường QRS, Q.4, TP.HCM', N'phamthid@gmail.com            ', N'0904567890 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH005     ', N'Võ Văn E', N'111 Đường TUV, Q.5, TP.HCM', N'vovan@gmail.com               ', N'0905678901 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH006     ', N'Nguyễn Thị F', N'222 Đường XYZ, Q.6, TP.HCM', N'nguyenthif@gmail.com          ', N'0906789012 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH007     ', N'Trần Văn G', N'333 Đường KLM, Q.7, TP.HCM', N'tranvang@gmail.com            ', N'0907890123 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH008     ', N'Lê Thị H', N'444 Đường QRS, Q.8, TP.HCM', N'lethi@gmail.com               ', N'0908901234 ')
INSERT [dbo].[KhachHang] ([KhachHangID], [HotenKH], [DiachiKH], [EmailKH], [SdtKH]) VALUES (N'KH009     ', N'Phạm Văn I', N'555 Đường TUV, Q.9, TP.HCM', N'phamvan@gmail.com             ', N'0909012345 ')
GO
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH001     ', N'Xe loại 1')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH002     ', N'Xe loại 2')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH003     ', N'Xe loại 3')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH004     ', N'Xe loại 4')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH005     ', N'Xe loại 5')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH006     ', N'Xe loại 6')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH007     ', N'Xe loại 7')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH008     ', N'Xe loại 8')
INSERT [dbo].[LoaiHang] ([loaihangID], [TenLH]) VALUES (N'LH009     ', N'Xe loại 9')
GO
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH001     ', N'XE001     ', N'Xiaomi Himo C20', N'5', 5000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH002     ', N'XE002     ', N'VanMoof S3', N'3', 6000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH003     ', N'XE003     ', N'Cowboy 3', N'2', 7000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH005     ', N'XE004     ', N'Specialized Turbo Vado SL', N'1', 8000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH006     ', N'XE005     ', N'Rad Power Bikes RadRover', N'7', 9000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH007     ', N'XE006     ', N'Trek Verve+ 2', N'4', 10000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH003     ', N'XE007     ', N'Giant Explore E+ 2', N'6', 11000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH002     ', N'XE008     ', N'Cannondale Quick Neo SL 2', N'9', 12000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH005     ', N'XE009     ', N'Riese & Müller Supercharger GT Touring', N'8', 13000000)
INSERT [dbo].[MatHang] ([LoaiHangID], [MathangID], [Tenhang], [SoLuong], [DonGia]) VALUES (N'LH002     ', N'XE010     ', N'Stromer ST1-X', N'10', 14000000)
GO
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC001    ', N'Công ty TNHH A', N'Đà Nẵng', N'0987654321 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC002    ', N'Công ty TNHH B', N'Hà Nội', N'0981234567 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC003    ', N'Công ty TNHH C', N'TP. HCM', N'0909090909 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC004    ', N'Công ty TNHH D', N'Hải Phòng', N'0912345678 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC005    ', N'Công ty TNHH E', N'Quảng Nam', N'0977777777 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC006    ', N'Công ty TNHH F', N'Bình Định', N'0966666666 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC007    ', N'Công ty TNHH G', N'Huế', N'0944444444 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC008    ', N'Công ty TNHH H', N'Đà Lạt', N'0933333333 ')
INSERT [dbo].[NHACC] ([NhaCCID], [TenNCC], [diachiNCC], [SdtNCC]) VALUES (N'NCC009    ', N'Công ty TNHH I', N'Vũng Tàu', N'0922222222 ')
GO
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV001     ', N'Nguyễn Văn A', N'Nam', CAST(N'1990-01-01' AS Date), N'Hà Nội', N'nva@gmail.com                 ', N'0987654321 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV002     ', N'Trần Thị B', N'Nữ', CAST(N'1995-05-05' AS Date), N'Hồ Chí Minh', N'ttb@gmail.com                 ', N'0123456789 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV003     ', N'Lê Minh C', N'Nam', CAST(N'1992-02-02' AS Date), N'Đà Nẵng', N'lmc@gmail.com                 ', N'0912345678 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV004     ', N'Phạm Thanh D', N'Nữ', CAST(N'1998-08-08' AS Date), N'Hà Nam', N'ptd@gmail.com                 ', N'0123456789 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV005     ', N'Vũ Văn E', N'Nam', CAST(N'1991-03-03' AS Date), N'Hải Phòng', N'vve@gmail.com                 ', N'0987654321 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV006     ', N'Đặng Thị F', N'Nữ', CAST(N'1993-04-04' AS Date), N'Hà Tĩnh', N'dtf@gmail.com                 ', N'0912345678 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV007     ', N'Nguyễn Thanh G', N'Nam', CAST(N'1990-01-01' AS Date), N'Quảng Ninh', N'ntg@gmail.com                 ', N'0123456789 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV008     ', N'Ngô Thị H', N'Nữ', CAST(N'1995-05-05' AS Date), N'Nghệ An', N'nth@gmail.com                 ', N'0987654321 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV009     ', N'Trần Văn I', N'Nam', CAST(N'1992-02-02' AS Date), N'Thanh Hóa', N'tvi@gmail.com                 ', N'0912345678 ')
INSERT [dbo].[NhanVien] ([NhanVienID], [HotenNV], [GioitinhNV], [NgaysinhNV], [diachiNV], [EmailNV], [SdtNV]) VALUES (N'NV010     ', N'Lê Thị K', N'Nữ', CAST(N'1998-08-08' AS Date), N'Hà Nội', N'ltk@gmail.com                 ', N'0123456789 ')
GO
INSERT [dbo].[TaiKhoan] ([TK], [MK]) VALUES (N'tuananh', N'123')
INSERT [dbo].[TaiKhoan] ([TK], [MK]) VALUES (N'tuananh123', N'12345678')
INSERT [dbo].[TaiKhoan] ([TK], [MK]) VALUES (N'tuananhabc', N'123')
INSERT [dbo].[TaiKhoan] ([TK], [MK]) VALUES (N'tuananhasd', N'123')
GO
ALTER TABLE [dbo].[ChitietDHB]  WITH CHECK ADD  CONSTRAINT [FK_ChitietDHB_Donhangban] FOREIGN KEY([DonhangbanID])
REFERENCES [dbo].[Donhangban] ([DonhangbanID])
GO
ALTER TABLE [dbo].[ChitietDHB] CHECK CONSTRAINT [FK_ChitietDHB_Donhangban]
GO
ALTER TABLE [dbo].[ChitietDHB]  WITH CHECK ADD  CONSTRAINT [FK_ChitietDHB_MatHang] FOREIGN KEY([MathangID])
REFERENCES [dbo].[MatHang] ([MathangID])
GO
ALTER TABLE [dbo].[ChitietDHB] CHECK CONSTRAINT [FK_ChitietDHB_MatHang]
GO
ALTER TABLE [dbo].[ChitietDHN]  WITH CHECK ADD  CONSTRAINT [FK_ChitietDHN_Donhangnhap] FOREIGN KEY([DonhangnhapID])
REFERENCES [dbo].[Donhangnhap] ([Donhangnhap])
GO
ALTER TABLE [dbo].[ChitietDHN] CHECK CONSTRAINT [FK_ChitietDHN_Donhangnhap]
GO
ALTER TABLE [dbo].[ChitietDHN]  WITH CHECK ADD  CONSTRAINT [FK_ChitietDHN_MatHang] FOREIGN KEY([MathangID])
REFERENCES [dbo].[MatHang] ([MathangID])
GO
ALTER TABLE [dbo].[ChitietDHN] CHECK CONSTRAINT [FK_ChitietDHN_MatHang]
GO
ALTER TABLE [dbo].[Donhangban]  WITH CHECK ADD  CONSTRAINT [FK_Donhangban_KhachHang] FOREIGN KEY([KhachhangID])
REFERENCES [dbo].[KhachHang] ([KhachHangID])
GO
ALTER TABLE [dbo].[Donhangban] CHECK CONSTRAINT [FK_Donhangban_KhachHang]
GO
ALTER TABLE [dbo].[Donhangban]  WITH CHECK ADD  CONSTRAINT [FK_Donhangban_NhanVien] FOREIGN KEY([NhanvienID])
REFERENCES [dbo].[NhanVien] ([NhanVienID])
GO
ALTER TABLE [dbo].[Donhangban] CHECK CONSTRAINT [FK_Donhangban_NhanVien]
GO
ALTER TABLE [dbo].[Donhangnhap]  WITH CHECK ADD  CONSTRAINT [FK_Donhangnhap_NHACC] FOREIGN KEY([NhaCCID])
REFERENCES [dbo].[NHACC] ([NhaCCID])
GO
ALTER TABLE [dbo].[Donhangnhap] CHECK CONSTRAINT [FK_Donhangnhap_NHACC]
GO
ALTER TABLE [dbo].[Donhangnhap]  WITH CHECK ADD  CONSTRAINT [FK_Donhangnhap_NhanVien] FOREIGN KEY([NhanvienID])
REFERENCES [dbo].[NhanVien] ([NhanVienID])
GO
ALTER TABLE [dbo].[Donhangnhap] CHECK CONSTRAINT [FK_Donhangnhap_NhanVien]
GO
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD  CONSTRAINT [FK_MatHang_LoaiHang] FOREIGN KEY([LoaiHangID])
REFERENCES [dbo].[LoaiHang] ([loaihangID])
GO
ALTER TABLE [dbo].[MatHang] CHECK CONSTRAINT [FK_MatHang_LoaiHang]
GO
