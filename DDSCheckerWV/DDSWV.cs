using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSCheckerWV
{
    public class DDSWV
    {      
        public struct DDS_Header
        {
            public uint magic;
            public uint dwSize;
            public uint dwFlags;
            public uint dwHeight;
            public uint dwWidth;
            public uint dwPitchOrLinearSize;
            public uint dwDepth;
            public uint dwMipMapCount;
            public uint[] dwReserved1;
            public DDS_PIXELFORMAT ddspf;
            public uint dwCaps;
            public uint dwCaps2;
            public uint dwCaps3;
            public uint dwCaps4;
            public uint dwReserved2;
            public DDS_HEADER_DXT10 extension;
        };

        public struct DDS_PIXELFORMAT
        {
            public uint dwSize;
            public uint dwFlags;
            public uint dwFourCC;
            public uint dwRGBBitCount;
            public uint dwRBitMask;
            public uint dwGBitMask;
            public uint dwBBitMask;
            public uint dwABitMask;
        };

        public enum DXGI_FORMAT
        {
            DXGI_FORMAT_UNKNOWN = 0,
            DXGI_FORMAT_R32G32B32A32_TYPELESS = 1,
            DXGI_FORMAT_R32G32B32A32_FLOAT = 2,
            DXGI_FORMAT_R32G32B32A32_UINT = 3,
            DXGI_FORMAT_R32G32B32A32_SINT = 4,
            DXGI_FORMAT_R32G32B32_TYPELESS = 5,
            DXGI_FORMAT_R32G32B32_FLOAT = 6,
            DXGI_FORMAT_R32G32B32_UINT = 7,
            DXGI_FORMAT_R32G32B32_SINT = 8,
            DXGI_FORMAT_R16G16B16A16_TYPELESS = 9,
            DXGI_FORMAT_R16G16B16A16_FLOAT = 10,
            DXGI_FORMAT_R16G16B16A16_UNORM = 11,
            DXGI_FORMAT_R16G16B16A16_UINT = 12,
            DXGI_FORMAT_R16G16B16A16_SNORM = 13,
            DXGI_FORMAT_R16G16B16A16_SINT = 14,
            DXGI_FORMAT_R32G32_TYPELESS = 15,
            DXGI_FORMAT_R32G32_FLOAT = 16,
            DXGI_FORMAT_R32G32_UINT = 17,
            DXGI_FORMAT_R32G32_SINT = 18,
            DXGI_FORMAT_R32G8X24_TYPELESS = 19,
            DXGI_FORMAT_D32_FLOAT_S8X24_UINT = 20,
            DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS = 21,
            DXGI_FORMAT_X32_TYPELESS_G8X24_UINT = 22,
            DXGI_FORMAT_R10G10B10A2_TYPELESS = 23,
            DXGI_FORMAT_R10G10B10A2_UNORM = 24,
            DXGI_FORMAT_R10G10B10A2_UINT = 25,
            DXGI_FORMAT_R11G11B10_FLOAT = 26,
            DXGI_FORMAT_R8G8B8A8_TYPELESS = 27,
            DXGI_FORMAT_R8G8B8A8_UNORM = 28,
            DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29,
            DXGI_FORMAT_R8G8B8A8_UINT = 30,
            DXGI_FORMAT_R8G8B8A8_SNORM = 31,
            DXGI_FORMAT_R8G8B8A8_SINT = 32,
            DXGI_FORMAT_R16G16_TYPELESS = 33,
            DXGI_FORMAT_R16G16_FLOAT = 34,
            DXGI_FORMAT_R16G16_UNORM = 35,
            DXGI_FORMAT_R16G16_UINT = 36,
            DXGI_FORMAT_R16G16_SNORM = 37,
            DXGI_FORMAT_R16G16_SINT = 38,
            DXGI_FORMAT_R32_TYPELESS = 39,
            DXGI_FORMAT_D32_FLOAT = 40,
            DXGI_FORMAT_R32_FLOAT = 41,
            DXGI_FORMAT_R32_UINT = 42,
            DXGI_FORMAT_R32_SINT = 43,
            DXGI_FORMAT_R24G8_TYPELESS = 44,
            DXGI_FORMAT_D24_UNORM_S8_UINT = 45,
            DXGI_FORMAT_R24_UNORM_X8_TYPELESS = 46,
            DXGI_FORMAT_X24_TYPELESS_G8_UINT = 47,
            DXGI_FORMAT_R8G8_TYPELESS = 48,
            DXGI_FORMAT_R8G8_UNORM = 49,
            DXGI_FORMAT_R8G8_UINT = 50,
            DXGI_FORMAT_R8G8_SNORM = 51,
            DXGI_FORMAT_R8G8_SINT = 52,
            DXGI_FORMAT_R16_TYPELESS = 53,
            DXGI_FORMAT_R16_FLOAT = 54,
            DXGI_FORMAT_D16_UNORM = 55,
            DXGI_FORMAT_R16_UNORM = 56,
            DXGI_FORMAT_R16_UINT = 57,
            DXGI_FORMAT_R16_SNORM = 58,
            DXGI_FORMAT_R16_SINT = 59,
            DXGI_FORMAT_R8_TYPELESS = 60,
            DXGI_FORMAT_R8_UNORM = 61,
            DXGI_FORMAT_R8_UINT = 62,
            DXGI_FORMAT_R8_SNORM = 63,
            DXGI_FORMAT_R8_SINT = 64,
            DXGI_FORMAT_A8_UNORM = 65,
            DXGI_FORMAT_R1_UNORM = 66,
            DXGI_FORMAT_R9G9B9E5_SHAREDEXP = 67,
            DXGI_FORMAT_R8G8_B8G8_UNORM = 68,
            DXGI_FORMAT_G8R8_G8B8_UNORM = 69,
            DXGI_FORMAT_BC1_TYPELESS = 70,
            DXGI_FORMAT_BC1_UNORM = 71,
            DXGI_FORMAT_BC1_UNORM_SRGB = 72,
            DXGI_FORMAT_BC2_TYPELESS = 73,
            DXGI_FORMAT_BC2_UNORM = 74,
            DXGI_FORMAT_BC2_UNORM_SRGB = 75,
            DXGI_FORMAT_BC3_TYPELESS = 76,
            DXGI_FORMAT_BC3_UNORM = 77,
            DXGI_FORMAT_BC3_UNORM_SRGB = 78,
            DXGI_FORMAT_BC4_TYPELESS = 79,
            DXGI_FORMAT_BC4_UNORM = 80,
            DXGI_FORMAT_BC4_SNORM = 81,
            DXGI_FORMAT_BC5_TYPELESS = 82,
            DXGI_FORMAT_BC5_UNORM = 83,
            DXGI_FORMAT_BC5_SNORM = 84,
            DXGI_FORMAT_B5G6R5_UNORM = 85,
            DXGI_FORMAT_B5G5R5A1_UNORM = 86,
            DXGI_FORMAT_B8G8R8A8_UNORM = 87,
            DXGI_FORMAT_B8G8R8X8_UNORM = 88,
            DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM = 89,
            DXGI_FORMAT_B8G8R8A8_TYPELESS = 90,
            DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91,
            DXGI_FORMAT_B8G8R8X8_TYPELESS = 92,
            DXGI_FORMAT_B8G8R8X8_UNORM_SRGB = 93,
            DXGI_FORMAT_BC6H_TYPELESS = 94,
            DXGI_FORMAT_BC6H_UF16 = 95,
            DXGI_FORMAT_BC6H_SF16 = 96,
            DXGI_FORMAT_BC7_TYPELESS = 97,
            DXGI_FORMAT_BC7_UNORM = 98,
            DXGI_FORMAT_BC7_UNORM_SRGB = 99,
            DXGI_FORMAT_AYUV = 100,
            DXGI_FORMAT_Y410 = 101,
            DXGI_FORMAT_Y416 = 102,
            DXGI_FORMAT_NV12 = 103,
            DXGI_FORMAT_P010 = 104,
            DXGI_FORMAT_P016 = 105,
            DXGI_FORMAT_420_OPAQUE = 106,
            DXGI_FORMAT_YUY2 = 107,
            DXGI_FORMAT_Y210 = 108,
            DXGI_FORMAT_Y216 = 109,
            DXGI_FORMAT_NV11 = 110,
            DXGI_FORMAT_AI44 = 111,
            DXGI_FORMAT_IA44 = 112,
            DXGI_FORMAT_P8 = 113,
            DXGI_FORMAT_A8P8 = 114,
            DXGI_FORMAT_B4G4R4A4_UNORM = 115,
            DXGI_FORMAT_P208 = 130,
            DXGI_FORMAT_V208 = 131,
            DXGI_FORMAT_V408 = 132,
            DXGI_FORMAT_FORCE_UINT = -1
        }

        public enum D3D10_RESOURCE_DIMENSION { 
            D3D10_RESOURCE_DIMENSION_UNKNOWN    = 0,
            D3D10_RESOURCE_DIMENSION_BUFFER     = 1,
            D3D10_RESOURCE_DIMENSION_TEXTURE1D  = 2,
            D3D10_RESOURCE_DIMENSION_TEXTURE2D  = 3,
            D3D10_RESOURCE_DIMENSION_TEXTURE3D  = 4
        }

        public enum D3D11_RESOURCE_MISC_FLAG
        {
            D3D11_RESOURCE_MISC_GENERATE_MIPS = 0x1,
            D3D11_RESOURCE_MISC_SHARED = 0x2,
            D3D11_RESOURCE_MISC_TEXTURECUBE = 0x4,
            D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS = 0x10,
            D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS = 0x20,
            D3D11_RESOURCE_MISC_BUFFER_STRUCTURED = 0x40,
            D3D11_RESOURCE_MISC_RESOURCE_CLAMP = 0x80,
            D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX = 0x100,
            D3D11_RESOURCE_MISC_GDI_COMPATIBLE = 0x200,
            D3D11_RESOURCE_MISC_SHARED_NTHANDLE = 0x800,
            D3D11_RESOURCE_MISC_RESTRICTED_CONTENT = 0x1000,
            D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE = 0x2000,
            D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER = 0x4000,
            D3D11_RESOURCE_MISC_GUARDED = 0x8000,
            D3D11_RESOURCE_MISC_TILE_POOL = 0x20000,
            D3D11_RESOURCE_MISC_TILED = 0x40000,
            D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000
        }

        public enum ALPHA_MODE
        {
            DDS_ALPHA_MODE_UNKNOWN	= 0x0,
            DDS_ALPHA_MODE_STRAIGHT	= 0x1,
            DDS_ALPHA_MODE_PREMULTIPLIED = 0x2,
            DDS_ALPHA_MODE_OPAQUE = 0x3,
            DDS_ALPHA_MODE_CUSTOM = 0x4
        }

        public struct DDS_HEADER_DXT10
        {
            public DXGI_FORMAT              dxgiFormat;
            public D3D10_RESOURCE_DIMENSION resourceDimension;
            public uint miscFlag;
            public uint arraySize;
            public ALPHA_MODE miscFlags2;
        }

        public DDSWV(string path)
        {
            Load(path);
        }

        public void Load(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Load(fs);
            fs.Close();
        }

        public DDS_Header Header;

        public void Load(Stream s)
        {
            Header = new DDS_Header();
            Header.magic = ReadUInt(s);
            Header.dwSize = ReadUInt(s);
            Header.dwFlags = ReadUInt(s);
            Header.dwHeight = ReadUInt(s);
            Header.dwWidth = ReadUInt(s);
            Header.dwPitchOrLinearSize = ReadUInt(s);
            Header.dwDepth = ReadUInt(s);
            Header.dwMipMapCount = ReadUInt(s);
            Header.dwReserved1 = new uint[11];
            for (int i = 0; i < 11; i++)
                Header.dwReserved1[i] = ReadUInt(s);
            Header.ddspf = ReadPixelFormat(s);
            Header.dwCaps = ReadUInt(s);
            Header.dwCaps2 = ReadUInt(s);
            Header.dwCaps3 = ReadUInt(s);
            Header.dwCaps4 = ReadUInt(s);
            Header.dwReserved2 = ReadUInt(s);
            if (Header.ddspf.dwFourCC == 0x30315844)
            {
                Header.extension = new DDS_HEADER_DXT10();
                Header.extension.dxgiFormat = (DXGI_FORMAT)ReadUInt(s);
                Header.extension.resourceDimension = (D3D10_RESOURCE_DIMENSION)ReadUInt(s);
                Header.extension.miscFlag = ReadUInt(s);
                Header.extension.arraySize = ReadUInt(s);
                Header.extension.miscFlags2 = (ALPHA_MODE)ReadUInt(s);
            }
        }

        private DDS_PIXELFORMAT ReadPixelFormat(Stream s)
        {
            DDS_PIXELFORMAT r = new DDS_PIXELFORMAT();
            r.dwSize = ReadUInt(s);
            r.dwFlags = ReadUInt(s);
            r.dwFourCC = ReadUInt(s);
            r.dwRGBBitCount = ReadUInt(s);
            r.dwRBitMask = ReadUInt(s);
            r.dwGBitMask = ReadUInt(s);
            r.dwBBitMask = ReadUInt(s);
            r.dwABitMask = ReadUInt(s);
            return r;
        }

        private uint ReadUInt(Stream s)
        {
            byte[] buff = new byte[4];
            s.Read(buff, 0, 4);
            return BitConverter.ToUInt32(buff,0);
        }

        private string UIntAsString(uint u)
        {
            byte[] buff = BitConverter.GetBytes(u);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buff)
                sb.Append((char)b);
            return sb.ToString();
        }

        private string UIntAsFlags(uint u)
        {
            StringBuilder sb = new StringBuilder();
            if ((u & 0x1) != 0)
                sb.Append("[DDSD_CAPS] ");
            if ((u & 0x2) != 0)
                sb.Append("[DDSD_HEIGHT] ");
            if ((u & 0x4) != 0)
                sb.Append("[DDSD_WIDTH] ");
            if ((u & 0x8) != 0)
                sb.Append("[DDSD_PITCH] ");
            if ((u & 0x1000) != 0)
                sb.Append("[DDSD_PIXELFORMAT] ");
            if ((u & 0x20000) != 0)
                sb.Append("[DDSD_MIPMAPCOUNT] ");
            if ((u & 0x80000) != 0)
                sb.Append("[DDSD_LINEARSIZE] ");
            if ((u & 0x800000) != 0)
                sb.Append("[DDSD_DEPTH] ");
            return sb.ToString();
        }

        private string UIntAsFlagsPF(uint u)
        {
            StringBuilder sb = new StringBuilder();
            if ((u & 0x1) != 0)
                sb.Append("[DDPF_ALPHAPIXELS] ");
            if ((u & 0x2) != 0)
                sb.Append("[DDPF_ALPHA] ");
            if ((u & 0x4) != 0)
                sb.Append("[DDPF_FOURCC] ");
            if ((u & 0x40) != 0)
                sb.Append("[DDPF_RGB] ");
            if ((u & 0x200) != 0)
                sb.Append("[DDPF_YUV] ");
            if ((u & 0x20000) != 0)
                sb.Append("[DDPF_LUMINANCE] ");
            return sb.ToString();
        }

        private string UIntAsCaps(uint u)
        {
            StringBuilder sb = new StringBuilder();
            if ((u & 0x8) != 0)
                sb.Append("[DDSCAPS_COMPLEX] ");
            if ((u & 0x1000) != 0)
                sb.Append("[DDSCAPS_TEXTURE] ");
            if ((u & 0x400000) != 0)
                sb.Append("[DDSCAPS_MIPMAP] ");
            return sb.ToString();
        }

        private string UIntAsCaps2(uint u)
        {
            StringBuilder sb = new StringBuilder();
            if ((u & 0x200) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP] ");
            if ((u & 0x400) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_POSITIVEX] ");
            if ((u & 0x800) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_NEGATIVEX] ");
            if ((u & 0x1000) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_POSITIVEY] ");
            if ((u & 0x2000) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_NEGATIVEY] ");
            if ((u & 0x4000) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_POSITIVEZ] ");
            if ((u & 0x8000) != 0)
                sb.Append("[DDSCAPS2_CUBEMAP_NEGATIVEZ] ");
            if ((u & 0x200000) != 0)
                sb.Append("[DDSCAPS2_VOLUME] ");
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("magic\t\t\t\t: 0x{0} - {1}\n", Header.magic.ToString("X8"), UIntAsString(Header.magic));
            sb.AppendFormat("dwSize\t\t\t: 0x{0} - {1}\n", Header.dwSize.ToString("X8"), Header.dwSize);
            sb.AppendFormat("dwFlags\t\t\t: 0x{0} - {1}\n", Header.dwFlags.ToString("X8"), UIntAsFlags(Header.dwFlags));
            sb.AppendFormat("dwHeight\t\t\t: 0x{0} - {1}\n", Header.dwHeight.ToString("X8"), Header.dwHeight);
            sb.AppendFormat("dwWidth\t\t\t: 0x{0} - {1}\n", Header.dwWidth.ToString("X8"), Header.dwWidth);
            sb.AppendFormat("dwPitchOrLinearSize\t: 0x{0} - {1}\n", Header.dwPitchOrLinearSize.ToString("X8"), Header.dwPitchOrLinearSize);
            sb.AppendFormat("dwDepth\t\t\t: 0x{0} - {1}\n", Header.dwDepth.ToString("X8"), Header.dwDepth);
            sb.AppendFormat("dwMipMapCount\t\t: 0x{0} - {1}\n", Header.dwMipMapCount.ToString("X8"), Header.dwMipMapCount);
            sb.AppendFormat("dwReserved1\n");
            int count = 0;
            foreach(uint u in Header.dwReserved1)
                sb.AppendFormat("\t\t\t\t\t{0} = 0x{1} - {1}\t\n", (count++).ToString("d2"), u.ToString("X8"), u);
            sb.AppendFormat("ddspf.dwSize\t\t: 0x{0} - {1}\n", Header.ddspf.dwSize.ToString("X8"), Header.ddspf.dwSize);
            sb.AppendFormat("ddspf.dwFlags\t\t: 0x{0} - {1}\n", Header.ddspf.dwFlags.ToString("X8"), UIntAsFlagsPF(Header.ddspf.dwFlags));
            sb.AppendFormat("ddspf.dwFourCC\t\t: 0x{0} - {1}\n", Header.ddspf.dwFourCC.ToString("X8"), UIntAsString(Header.ddspf.dwFourCC));
            sb.AppendFormat("ddspf.dwRGBBitCount\t: 0x{0} - {1}\n", Header.ddspf.dwRGBBitCount.ToString("X8"), Header.ddspf.dwRGBBitCount);
            sb.AppendFormat("ddspf.dwRBitMask\t\t: 0x{0} - {1}\n", Header.ddspf.dwRBitMask.ToString("X8"), Header.ddspf.dwRBitMask);
            sb.AppendFormat("ddspf.dwGBitMask\t\t: 0x{0} - {1}\n", Header.ddspf.dwGBitMask.ToString("X8"), Header.ddspf.dwGBitMask);
            sb.AppendFormat("ddspf.dwBBitMask\t\t: 0x{0} - {1}\n", Header.ddspf.dwBBitMask.ToString("X8"), Header.ddspf.dwBBitMask);
            sb.AppendFormat("ddspf.dwABitMask\t\t: 0x{0} - {1}\n", Header.ddspf.dwABitMask.ToString("X8"), Header.ddspf.dwABitMask);
            sb.AppendFormat("dwCaps\t\t\t: 0x{0} - {1}\n", Header.dwCaps.ToString("X8"), UIntAsCaps(Header.dwCaps));
            sb.AppendFormat("dwCaps2\t\t\t: 0x{0} - {1}\n", Header.dwCaps2.ToString("X8"), UIntAsCaps2(Header.dwCaps2));
            sb.AppendFormat("dwCaps3\t\t\t: 0x{0} - {1}\n", Header.dwCaps3.ToString("X8"), Header.dwCaps3);
            sb.AppendFormat("dwCaps4\t\t\t: 0x{0} - {1}\n", Header.dwCaps4.ToString("X8"), Header.dwCaps4);
            sb.AppendFormat("dwReserved2\t\t\t: 0x{0} - {1}\n", Header.dwReserved2.ToString("X8"), Header.dwReserved2);
            if (Header.ddspf.dwFourCC == 0x30315844)
            {
                sb.AppendLine("[DX10 Extension]");
                sb.AppendFormat("Format\t\t\t: {0} \n", Header.extension.dxgiFormat);
                sb.AppendFormat("Ressource Dimension\t: {0} \n", Header.extension.resourceDimension);
                sb.Append("Misc Flags\t\t\t: 0x" + Header.extension.miscFlag.ToString("X8") + " ");
                foreach (int flag in Enum.GetValues(typeof(D3D11_RESOURCE_MISC_FLAG)))
                    if ((flag & Header.extension.miscFlag) != 0)
                        sb.Append("[" + (D3D11_RESOURCE_MISC_FLAG)flag + "]");
                sb.AppendLine();
                sb.AppendFormat("Array Size\t\t\t: 0x{0}\n", Header.extension.arraySize.ToString("X8"));
                sb.Append("Misc Flags 2\t\t: 0x" + ((uint)(Header.extension.miscFlags2)).ToString("X8") + " " + Header.extension.miscFlags2);
            }
            return sb.ToString();
        }
    }
}
