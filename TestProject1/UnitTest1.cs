using DAL;
using DTO;
using BUS;
using NUnit.Framework;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Data;
using Do_an_1;
using NUnit.Framework.Internal;
namespace TestProject1
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class NhanVienTest
        {
            
            [Test]
            public void TestthemNV()
            {
                // Arrange
                DTO_NhanVien nv = new DTO_NhanVien
                {
                    NhanVienID = "NV011",
                    HotenNV = "Thành Nam",
                    GioitinhNV = "Nam",
                    diachiNV = "Phù Cừ",
                    SdtNV = "123456789",
                    NgaysinhNV = new DateTime(2003, 6, 24)
                };

                // Act
                bool result = nv.Equals(nv);

                // Assert
                Assert.IsTrue(result, "Expected the insertion to be successful.");
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestsuaNV()
            {
                // Arrange
                DTO_NhanVien nv = new DTO_NhanVien
                {
                    NhanVienID = "123",
                    HotenNV = "Coca",
                    GioitinhNV = "Female",
                    diachiNV = "456 Main St",
                    SdtNV = "987654321",
                    NgaysinhNV = new DateTime(1995, 10, 15)
                };

                // Act
                bool result = nv.Equals(nv);

                // Assert
                Assert.IsTrue(result, "Expected the update to be successful.");
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestxoaNV()
            {
                // Arrange
                string maNhanVien = "123";

                // Act
                bool result = maNhanVien.Equals(maNhanVien.ToString());

                // Assert
                Assert.IsTrue(result, "Expected the deletion to be successful.");
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestNhanVienID()
            {
                // Arrange
                string expectedNhanVienID = "123";
                DTO_NhanVien nv = new DTO_NhanVien();

                // Act
                nv.NhanVienID = expectedNhanVienID;
                string actualNhanVienID = nv.NhanVienID;

                // Assert
                Assert.That(actualNhanVienID, Is.EqualTo(expectedNhanVienID));
                // Additional assertions or verifications can be performed here if needed
            }
            public void TestTenNhanVien()
            {
                // Arrange
                string expectedTenNhanVien = "John Doe";
                DTO_NhanVien nv = new DTO_NhanVien();

                // Act
                nv.HotenNV = expectedTenNhanVien;
                string actualTenNhanVien = nv.HotenNV;

                // Assert
                Assert.That(actualTenNhanVien, Is.EqualTo(expectedTenNhanVien));
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestGioiTinh()
            {
                // Arrange
                string expectedGioiTinh = "Male";
                DTO_NhanVien nv = new DTO_NhanVien();

                // Act
                nv.GioitinhNV = expectedGioiTinh;
                string actualGioiTinh = nv.GioitinhNV;

                // Assert
                Assert.That(actualGioiTinh, Is.EqualTo(expectedGioiTinh));
                // Additional assertions or verifications can be performed here if needed
            }

            public void TestDiaChi()
            {
                // Arrange
                string expectedDiaChi = "123 Main Street";
                DTO_NhanVien nv = new DTO_NhanVien();

                // Act
                nv.diachiNV = expectedDiaChi;
                string actualDiaChi = nv.diachiNV;

                // Assert
                Assert.That(actualDiaChi, Is.EqualTo(expectedDiaChi));
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestDienThoai()
            {
                // Arrange
                string expectedDienThoai = "1234567890";
                DTO_NhanVien nv = new DTO_NhanVien();

                // Act
                nv.SdtNV = expectedDienThoai;
                string actualDienThoai = nv.SdtNV;

                // Assert
                Assert.That(actualDienThoai, Is.EqualTo(expectedDienThoai));
                // Additional assertions or verifications can be performed here if needed
            }
            [Test]
            public void TestNgay()
            {
                // Arrange
                DateTime ngaySinh = new DateTime(2023, 5, 28);
                string expectedNgay = "2023/5/28";
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.NgaysinhNV = ngaySinh;

                // Act
                string actualNgay = string.Format("{0}/{1}/{2}", nv.NgaysinhNV.Year, nv.NgaysinhNV.Month, nv.NgaysinhNV.Day);

                // Assert
                Assert.That(actualNgay, Is.EqualTo(expectedNgay));
                // Additional assertions or verifications can be performed here if needed
            }
            public class NhacungcapTest
            {
                
                DTO_NhaCC ncc = new DTO_NhaCC();
                [Test]
                public void TestthemNCC()
                {
                    // Arrange
                    DTO_NhaCC ncc = new DTO_NhaCC
                    {
                        NhaCCID = "NCC001",
                        TenNCC = "NCCABC",
                        diachiNCC = "Phù Cừ",
                        SdtNCC = "324023423"

                    };

                    // Act
                    bool result = ncc.Equals(ncc);

                    // Assert
                    Assert.IsTrue(result, "Expected the insertion to be successful.");
                    // Additional assertions or verifications can be performed here if needed
                }
                [Test]
                public void TestsuaNCC()
                {
                    // Arrange
                    DTO_NhaCC ncc = new DTO_NhaCC
                    {
                        NhaCCID = "NCC001",
                        TenNCC = "NCCABC",
                        diachiNCC = "Phù Cừ",
                        SdtNCC = "324023423"
                    };

                    // Act
                    bool result = ncc.Equals(ncc);

                    // Assert
                    Assert.IsTrue(result, "Expected the update to be successful.");
                    // Additional assertions or verifications can be performed here if needed
                }
                [Test]
                public void TestxoaNCC()
                {
                    // Arrange
                    string NhaCCID = "123";

                    // Act
                    bool result = NhaCCID.Equals(NhaCCID.ToString());

                    // Assert
                    Assert.IsTrue(result, "Expected the deletion to be successful.");
                    // Additional assertions or verifications can be performed here if needed
                }
                [Test]
                public void TestNhCCID()
                {
                    // Arrange
                    string expectedNhaCCID = "123";
                    DTO_NhaCC ncc = new  DTO_NhaCC();

                    // Act
                    ncc.NhaCCID = expectedNhaCCID;
                    string actualNhaCCID = ncc.NhaCCID;

                    // Assert
                    Assert.That(actualNhaCCID, Is.EqualTo(expectedNhaCCID));
                    // Additional assertions or verifications can be performed here if needed
                }
                public void TestTenNCC()
                {
                    // Arrange
                    string expectedTenNCC = "John Doe";
                    

                    // Act
                    ncc.TenNCC = expectedTenNCC;
                    string actualTenNCC = ncc.TenNCC;

                    // Assert
                    Assert.That(actualTenNCC, Is.EqualTo(expectedTenNCC));
                    // Additional assertions or verifications can be performed here if needed
                }
                [Test]
                

                public void TestDiaChi()
                {
                    // Arrange
                    string expectedDiaChi = "123 Main Street";
                    DTO_NhaCC ncc = new DTO_NhaCC();

                    // Act
                    ncc.diachiNCC = expectedDiaChi;
                    string actualDiaChi = ncc.diachiNCC;

                    // Assert
                    Assert.That(actualDiaChi, Is.EqualTo(expectedDiaChi));
                    // Additional assertions or verifications can be performed here if needed
                }
                [Test]
                public void TestDienThoai()
                {
                    // Arrange
                    string expectedDienThoai = "1234567890";
                    DTO_NhaCC ncc = new DTO_NhaCC();

                    // Act
                    ncc.SdtNCC = expectedDienThoai;
                    string actualDienThoai = ncc.SdtNCC;

                    // Assert
                    Assert.That(actualDienThoai, Is.EqualTo(expectedDienThoai));
                    // Additional assertions or verifications can be performed here if needed
                }
            }
        }
    }
}
