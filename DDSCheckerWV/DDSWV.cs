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
            return sb.ToString();
        }
    }
}
