﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Substrate.NetApi.Model.Types.Base
{

    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
 
    /* UNITY IL2CPP BUG    

    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251, T252> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
       where T252 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                case 0xFB: return DecodeType<T252>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251, T252, T253> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
       where T252 : IType, new()
       where T253 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                case 0xFB: return DecodeType<T252>(byteArray, ref p);
                case 0xFC: return DecodeType<T253>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251, T252, T253, T254> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
       where T252 : IType, new()
       where T253 : IType, new()
       where T254 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                case 0xFB: return DecodeType<T252>(byteArray, ref p);
                case 0xFC: return DecodeType<T253>(byteArray, ref p);
                case 0xFD: return DecodeType<T254>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251, T252, T253, T254, T255> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
       where T252 : IType, new()
       where T253 : IType, new()
       where T254 : IType, new()
       where T255 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                case 0xFB: return DecodeType<T252>(byteArray, ref p);
                case 0xFC: return DecodeType<T253>(byteArray, ref p);
                case 0xFD: return DecodeType<T254>(byteArray, ref p);
                case 0xFE: return DecodeType<T255>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }
    
    */

    /// <inheritdoc/>
    public class BaseEnumExt<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68, T69, T70, T71, T72, T73, T74, T75, T76, T77, T78, T79, T80, T81, T82, T83, T84, T85, T86, T87, T88, T89, T90, T91, T92, T93, T94, T95, T96, T97, T98, T99, T100, T101, T102, T103, T104, T105, T106, T107, T108, T109, T110, T111, T112, T113, T114, T115, T116, T117, T118, T119, T120, T121, T122, T123, T124, T125, T126, T127, T128, T129, T130, T131, T132, T133, T134, T135, T136, T137, T138, T139, T140, T141, T142, T143, T144, T145, T146, T147, T148, T149, T150, T151, T152, T153, T154, T155, T156, T157, T158, T159, T160, T161, T162, T163, T164, T165, T166, T167, T168, T169, T170, T171, T172, T173, T174, T175, T176, T177, T178, T179, T180, T181, T182, T183, T184, T185, T186, T187, T188, T189, T190, T191, T192, T193, T194, T195, T196, T197, T198, T199, T200, T201, T202, T203, T204, T205, T206, T207, T208, T209, T210, T211, T212, T213, T214, T215, T216, T217, T218, T219, T220, T221, T222, T223, T224, T225, T226, T227, T228, T229, T230, T231, T232, T233, T234, T235, T236, T237, T238, T239, T240, T241, T242, T243, T244, T245, T246, T247, T248, T249, T250, T251, T252, T253, T254, T255, T256> : BaseEnumType
       where T0 : Enum
       where T1 : IType, new()
       where T2 : IType, new()
       where T3 : IType, new()
       where T4 : IType, new()
       where T5 : IType, new()
       where T6 : IType, new()
       where T7 : IType, new()
       where T8 : IType, new()
       where T9 : IType, new()
       where T10 : IType, new()
       where T11 : IType, new()
       where T12 : IType, new()
       where T13 : IType, new()
       where T14 : IType, new()
       where T15 : IType, new()
       where T16 : IType, new()
       where T17 : IType, new()
       where T18 : IType, new()
       where T19 : IType, new()
       where T20 : IType, new()
       where T21 : IType, new()
       where T22 : IType, new()
       where T23 : IType, new()
       where T24 : IType, new()
       where T25 : IType, new()
       where T26 : IType, new()
       where T27 : IType, new()
       where T28 : IType, new()
       where T29 : IType, new()
       where T30 : IType, new()
       where T31 : IType, new()
       where T32 : IType, new()
       where T33 : IType, new()
       where T34 : IType, new()
       where T35 : IType, new()
       where T36 : IType, new()
       where T37 : IType, new()
       where T38 : IType, new()
       where T39 : IType, new()
       where T40 : IType, new()
       where T41 : IType, new()
       where T42 : IType, new()
       where T43 : IType, new()
       where T44 : IType, new()
       where T45 : IType, new()
       where T46 : IType, new()
       where T47 : IType, new()
       where T48 : IType, new()
       where T49 : IType, new()
       where T50 : IType, new()
       where T51 : IType, new()
       where T52 : IType, new()
       where T53 : IType, new()
       where T54 : IType, new()
       where T55 : IType, new()
       where T56 : IType, new()
       where T57 : IType, new()
       where T58 : IType, new()
       where T59 : IType, new()
       where T60 : IType, new()
       where T61 : IType, new()
       where T62 : IType, new()
       where T63 : IType, new()
       where T64 : IType, new()
       where T65 : IType, new()
       where T66 : IType, new()
       where T67 : IType, new()
       where T68 : IType, new()
       where T69 : IType, new()
       where T70 : IType, new()
       where T71 : IType, new()
       where T72 : IType, new()
       where T73 : IType, new()
       where T74 : IType, new()
       where T75 : IType, new()
       where T76 : IType, new()
       where T77 : IType, new()
       where T78 : IType, new()
       where T79 : IType, new()
       where T80 : IType, new()
       where T81 : IType, new()
       where T82 : IType, new()
       where T83 : IType, new()
       where T84 : IType, new()
       where T85 : IType, new()
       where T86 : IType, new()
       where T87 : IType, new()
       where T88 : IType, new()
       where T89 : IType, new()
       where T90 : IType, new()
       where T91 : IType, new()
       where T92 : IType, new()
       where T93 : IType, new()
       where T94 : IType, new()
       where T95 : IType, new()
       where T96 : IType, new()
       where T97 : IType, new()
       where T98 : IType, new()
       where T99 : IType, new()
       where T100 : IType, new()
       where T101 : IType, new()
       where T102 : IType, new()
       where T103 : IType, new()
       where T104 : IType, new()
       where T105 : IType, new()
       where T106 : IType, new()
       where T107 : IType, new()
       where T108 : IType, new()
       where T109 : IType, new()
       where T110 : IType, new()
       where T111 : IType, new()
       where T112 : IType, new()
       where T113 : IType, new()
       where T114 : IType, new()
       where T115 : IType, new()
       where T116 : IType, new()
       where T117 : IType, new()
       where T118 : IType, new()
       where T119 : IType, new()
       where T120 : IType, new()
       where T121 : IType, new()
       where T122 : IType, new()
       where T123 : IType, new()
       where T124 : IType, new()
       where T125 : IType, new()
       where T126 : IType, new()
       where T127 : IType, new()
       where T128 : IType, new()
       where T129 : IType, new()
       where T130 : IType, new()
       where T131 : IType, new()
       where T132 : IType, new()
       where T133 : IType, new()
       where T134 : IType, new()
       where T135 : IType, new()
       where T136 : IType, new()
       where T137 : IType, new()
       where T138 : IType, new()
       where T139 : IType, new()
       where T140 : IType, new()
       where T141 : IType, new()
       where T142 : IType, new()
       where T143 : IType, new()
       where T144 : IType, new()
       where T145 : IType, new()
       where T146 : IType, new()
       where T147 : IType, new()
       where T148 : IType, new()
       where T149 : IType, new()
       where T150 : IType, new()
       where T151 : IType, new()
       where T152 : IType, new()
       where T153 : IType, new()
       where T154 : IType, new()
       where T155 : IType, new()
       where T156 : IType, new()
       where T157 : IType, new()
       where T158 : IType, new()
       where T159 : IType, new()
       where T160 : IType, new()
       where T161 : IType, new()
       where T162 : IType, new()
       where T163 : IType, new()
       where T164 : IType, new()
       where T165 : IType, new()
       where T166 : IType, new()
       where T167 : IType, new()
       where T168 : IType, new()
       where T169 : IType, new()
       where T170 : IType, new()
       where T171 : IType, new()
       where T172 : IType, new()
       where T173 : IType, new()
       where T174 : IType, new()
       where T175 : IType, new()
       where T176 : IType, new()
       where T177 : IType, new()
       where T178 : IType, new()
       where T179 : IType, new()
       where T180 : IType, new()
       where T181 : IType, new()
       where T182 : IType, new()
       where T183 : IType, new()
       where T184 : IType, new()
       where T185 : IType, new()
       where T186 : IType, new()
       where T187 : IType, new()
       where T188 : IType, new()
       where T189 : IType, new()
       where T190 : IType, new()
       where T191 : IType, new()
       where T192 : IType, new()
       where T193 : IType, new()
       where T194 : IType, new()
       where T195 : IType, new()
       where T196 : IType, new()
       where T197 : IType, new()
       where T198 : IType, new()
       where T199 : IType, new()
       where T200 : IType, new()
       where T201 : IType, new()
       where T202 : IType, new()
       where T203 : IType, new()
       where T204 : IType, new()
       where T205 : IType, new()
       where T206 : IType, new()
       where T207 : IType, new()
       where T208 : IType, new()
       where T209 : IType, new()
       where T210 : IType, new()
       where T211 : IType, new()
       where T212 : IType, new()
       where T213 : IType, new()
       where T214 : IType, new()
       where T215 : IType, new()
       where T216 : IType, new()
       where T217 : IType, new()
       where T218 : IType, new()
       where T219 : IType, new()
       where T220 : IType, new()
       where T221 : IType, new()
       where T222 : IType, new()
       where T223 : IType, new()
       where T224 : IType, new()
       where T225 : IType, new()
       where T226 : IType, new()
       where T227 : IType, new()
       where T228 : IType, new()
       where T229 : IType, new()
       where T230 : IType, new()
       where T231 : IType, new()
       where T232 : IType, new()
       where T233 : IType, new()
       where T234 : IType, new()
       where T235 : IType, new()
       where T236 : IType, new()
       where T237 : IType, new()
       where T238 : IType, new()
       where T239 : IType, new()
       where T240 : IType, new()
       where T241 : IType, new()
       where T242 : IType, new()
       where T243 : IType, new()
       where T244 : IType, new()
       where T245 : IType, new()
       where T246 : IType, new()
       where T247 : IType, new()
       where T248 : IType, new()
       where T249 : IType, new()
       where T250 : IType, new()
       where T251 : IType, new()
       where T252 : IType, new()
       where T253 : IType, new()
       where T254 : IType, new()
       where T255 : IType, new()
       where T256 : IType, new()
    {
        /// <inheritdoc/>
        public override string TypeName() => typeof(T0).Name;

        /// <inheritdoc/>
        public override byte[] Encode()
        {
            return Bytes;
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var enumByte = byteArray[p];

            Value = (T0)Enum.Parse(typeof(T0), enumByte.ToString(), true);
            p += 1;

            Value2 = DecodeOneOf(enumByte, byteArray, ref p);

            TypeSize = p - start;

            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }

        /// <summary>
        /// BaseEnumExt DecodeOneOf
        /// </summary>
        private IType DecodeOneOf(byte value, byte[] byteArray, ref int p)
        {
            switch (value)
            {
                case 0x00: return DecodeType<T1>(byteArray, ref p);
                case 0x01: return DecodeType<T2>(byteArray, ref p);
                case 0x02: return DecodeType<T3>(byteArray, ref p);
                case 0x03: return DecodeType<T4>(byteArray, ref p);
                case 0x04: return DecodeType<T5>(byteArray, ref p);
                case 0x05: return DecodeType<T6>(byteArray, ref p);
                case 0x06: return DecodeType<T7>(byteArray, ref p);
                case 0x07: return DecodeType<T8>(byteArray, ref p);
                case 0x08: return DecodeType<T9>(byteArray, ref p);
                case 0x09: return DecodeType<T10>(byteArray, ref p);
                case 0x0A: return DecodeType<T11>(byteArray, ref p);
                case 0x0B: return DecodeType<T12>(byteArray, ref p);
                case 0x0C: return DecodeType<T13>(byteArray, ref p);
                case 0x0D: return DecodeType<T14>(byteArray, ref p);
                case 0x0E: return DecodeType<T15>(byteArray, ref p);
                case 0x0F: return DecodeType<T16>(byteArray, ref p);
                case 0x10: return DecodeType<T17>(byteArray, ref p);
                case 0x11: return DecodeType<T18>(byteArray, ref p);
                case 0x12: return DecodeType<T19>(byteArray, ref p);
                case 0x13: return DecodeType<T20>(byteArray, ref p);
                case 0x14: return DecodeType<T21>(byteArray, ref p);
                case 0x15: return DecodeType<T22>(byteArray, ref p);
                case 0x16: return DecodeType<T23>(byteArray, ref p);
                case 0x17: return DecodeType<T24>(byteArray, ref p);
                case 0x18: return DecodeType<T25>(byteArray, ref p);
                case 0x19: return DecodeType<T26>(byteArray, ref p);
                case 0x1A: return DecodeType<T27>(byteArray, ref p);
                case 0x1B: return DecodeType<T28>(byteArray, ref p);
                case 0x1C: return DecodeType<T29>(byteArray, ref p);
                case 0x1D: return DecodeType<T30>(byteArray, ref p);
                case 0x1E: return DecodeType<T31>(byteArray, ref p);
                case 0x1F: return DecodeType<T32>(byteArray, ref p);
                case 0x20: return DecodeType<T33>(byteArray, ref p);
                case 0x21: return DecodeType<T34>(byteArray, ref p);
                case 0x22: return DecodeType<T35>(byteArray, ref p);
                case 0x23: return DecodeType<T36>(byteArray, ref p);
                case 0x24: return DecodeType<T37>(byteArray, ref p);
                case 0x25: return DecodeType<T38>(byteArray, ref p);
                case 0x26: return DecodeType<T39>(byteArray, ref p);
                case 0x27: return DecodeType<T40>(byteArray, ref p);
                case 0x28: return DecodeType<T41>(byteArray, ref p);
                case 0x29: return DecodeType<T42>(byteArray, ref p);
                case 0x2A: return DecodeType<T43>(byteArray, ref p);
                case 0x2B: return DecodeType<T44>(byteArray, ref p);
                case 0x2C: return DecodeType<T45>(byteArray, ref p);
                case 0x2D: return DecodeType<T46>(byteArray, ref p);
                case 0x2E: return DecodeType<T47>(byteArray, ref p);
                case 0x2F: return DecodeType<T48>(byteArray, ref p);
                case 0x30: return DecodeType<T49>(byteArray, ref p);
                case 0x31: return DecodeType<T50>(byteArray, ref p);
                case 0x32: return DecodeType<T51>(byteArray, ref p);
                case 0x33: return DecodeType<T52>(byteArray, ref p);
                case 0x34: return DecodeType<T53>(byteArray, ref p);
                case 0x35: return DecodeType<T54>(byteArray, ref p);
                case 0x36: return DecodeType<T55>(byteArray, ref p);
                case 0x37: return DecodeType<T56>(byteArray, ref p);
                case 0x38: return DecodeType<T57>(byteArray, ref p);
                case 0x39: return DecodeType<T58>(byteArray, ref p);
                case 0x3A: return DecodeType<T59>(byteArray, ref p);
                case 0x3B: return DecodeType<T60>(byteArray, ref p);
                case 0x3C: return DecodeType<T61>(byteArray, ref p);
                case 0x3D: return DecodeType<T62>(byteArray, ref p);
                case 0x3E: return DecodeType<T63>(byteArray, ref p);
                case 0x3F: return DecodeType<T64>(byteArray, ref p);
                case 0x40: return DecodeType<T65>(byteArray, ref p);
                case 0x41: return DecodeType<T66>(byteArray, ref p);
                case 0x42: return DecodeType<T67>(byteArray, ref p);
                case 0x43: return DecodeType<T68>(byteArray, ref p);
                case 0x44: return DecodeType<T69>(byteArray, ref p);
                case 0x45: return DecodeType<T70>(byteArray, ref p);
                case 0x46: return DecodeType<T71>(byteArray, ref p);
                case 0x47: return DecodeType<T72>(byteArray, ref p);
                case 0x48: return DecodeType<T73>(byteArray, ref p);
                case 0x49: return DecodeType<T74>(byteArray, ref p);
                case 0x4A: return DecodeType<T75>(byteArray, ref p);
                case 0x4B: return DecodeType<T76>(byteArray, ref p);
                case 0x4C: return DecodeType<T77>(byteArray, ref p);
                case 0x4D: return DecodeType<T78>(byteArray, ref p);
                case 0x4E: return DecodeType<T79>(byteArray, ref p);
                case 0x4F: return DecodeType<T80>(byteArray, ref p);
                case 0x50: return DecodeType<T81>(byteArray, ref p);
                case 0x51: return DecodeType<T82>(byteArray, ref p);
                case 0x52: return DecodeType<T83>(byteArray, ref p);
                case 0x53: return DecodeType<T84>(byteArray, ref p);
                case 0x54: return DecodeType<T85>(byteArray, ref p);
                case 0x55: return DecodeType<T86>(byteArray, ref p);
                case 0x56: return DecodeType<T87>(byteArray, ref p);
                case 0x57: return DecodeType<T88>(byteArray, ref p);
                case 0x58: return DecodeType<T89>(byteArray, ref p);
                case 0x59: return DecodeType<T90>(byteArray, ref p);
                case 0x5A: return DecodeType<T91>(byteArray, ref p);
                case 0x5B: return DecodeType<T92>(byteArray, ref p);
                case 0x5C: return DecodeType<T93>(byteArray, ref p);
                case 0x5D: return DecodeType<T94>(byteArray, ref p);
                case 0x5E: return DecodeType<T95>(byteArray, ref p);
                case 0x5F: return DecodeType<T96>(byteArray, ref p);
                case 0x60: return DecodeType<T97>(byteArray, ref p);
                case 0x61: return DecodeType<T98>(byteArray, ref p);
                case 0x62: return DecodeType<T99>(byteArray, ref p);
                case 0x63: return DecodeType<T100>(byteArray, ref p);
                case 0x64: return DecodeType<T101>(byteArray, ref p);
                case 0x65: return DecodeType<T102>(byteArray, ref p);
                case 0x66: return DecodeType<T103>(byteArray, ref p);
                case 0x67: return DecodeType<T104>(byteArray, ref p);
                case 0x68: return DecodeType<T105>(byteArray, ref p);
                case 0x69: return DecodeType<T106>(byteArray, ref p);
                case 0x6A: return DecodeType<T107>(byteArray, ref p);
                case 0x6B: return DecodeType<T108>(byteArray, ref p);
                case 0x6C: return DecodeType<T109>(byteArray, ref p);
                case 0x6D: return DecodeType<T110>(byteArray, ref p);
                case 0x6E: return DecodeType<T111>(byteArray, ref p);
                case 0x6F: return DecodeType<T112>(byteArray, ref p);
                case 0x70: return DecodeType<T113>(byteArray, ref p);
                case 0x71: return DecodeType<T114>(byteArray, ref p);
                case 0x72: return DecodeType<T115>(byteArray, ref p);
                case 0x73: return DecodeType<T116>(byteArray, ref p);
                case 0x74: return DecodeType<T117>(byteArray, ref p);
                case 0x75: return DecodeType<T118>(byteArray, ref p);
                case 0x76: return DecodeType<T119>(byteArray, ref p);
                case 0x77: return DecodeType<T120>(byteArray, ref p);
                case 0x78: return DecodeType<T121>(byteArray, ref p);
                case 0x79: return DecodeType<T122>(byteArray, ref p);
                case 0x7A: return DecodeType<T123>(byteArray, ref p);
                case 0x7B: return DecodeType<T124>(byteArray, ref p);
                case 0x7C: return DecodeType<T125>(byteArray, ref p);
                case 0x7D: return DecodeType<T126>(byteArray, ref p);
                case 0x7E: return DecodeType<T127>(byteArray, ref p);
                case 0x7F: return DecodeType<T128>(byteArray, ref p);
                case 0x80: return DecodeType<T129>(byteArray, ref p);
                case 0x81: return DecodeType<T130>(byteArray, ref p);
                case 0x82: return DecodeType<T131>(byteArray, ref p);
                case 0x83: return DecodeType<T132>(byteArray, ref p);
                case 0x84: return DecodeType<T133>(byteArray, ref p);
                case 0x85: return DecodeType<T134>(byteArray, ref p);
                case 0x86: return DecodeType<T135>(byteArray, ref p);
                case 0x87: return DecodeType<T136>(byteArray, ref p);
                case 0x88: return DecodeType<T137>(byteArray, ref p);
                case 0x89: return DecodeType<T138>(byteArray, ref p);
                case 0x8A: return DecodeType<T139>(byteArray, ref p);
                case 0x8B: return DecodeType<T140>(byteArray, ref p);
                case 0x8C: return DecodeType<T141>(byteArray, ref p);
                case 0x8D: return DecodeType<T142>(byteArray, ref p);
                case 0x8E: return DecodeType<T143>(byteArray, ref p);
                case 0x8F: return DecodeType<T144>(byteArray, ref p);
                case 0x90: return DecodeType<T145>(byteArray, ref p);
                case 0x91: return DecodeType<T146>(byteArray, ref p);
                case 0x92: return DecodeType<T147>(byteArray, ref p);
                case 0x93: return DecodeType<T148>(byteArray, ref p);
                case 0x94: return DecodeType<T149>(byteArray, ref p);
                case 0x95: return DecodeType<T150>(byteArray, ref p);
                case 0x96: return DecodeType<T151>(byteArray, ref p);
                case 0x97: return DecodeType<T152>(byteArray, ref p);
                case 0x98: return DecodeType<T153>(byteArray, ref p);
                case 0x99: return DecodeType<T154>(byteArray, ref p);
                case 0x9A: return DecodeType<T155>(byteArray, ref p);
                case 0x9B: return DecodeType<T156>(byteArray, ref p);
                case 0x9C: return DecodeType<T157>(byteArray, ref p);
                case 0x9D: return DecodeType<T158>(byteArray, ref p);
                case 0x9E: return DecodeType<T159>(byteArray, ref p);
                case 0x9F: return DecodeType<T160>(byteArray, ref p);
                case 0xA0: return DecodeType<T161>(byteArray, ref p);
                case 0xA1: return DecodeType<T162>(byteArray, ref p);
                case 0xA2: return DecodeType<T163>(byteArray, ref p);
                case 0xA3: return DecodeType<T164>(byteArray, ref p);
                case 0xA4: return DecodeType<T165>(byteArray, ref p);
                case 0xA5: return DecodeType<T166>(byteArray, ref p);
                case 0xA6: return DecodeType<T167>(byteArray, ref p);
                case 0xA7: return DecodeType<T168>(byteArray, ref p);
                case 0xA8: return DecodeType<T169>(byteArray, ref p);
                case 0xA9: return DecodeType<T170>(byteArray, ref p);
                case 0xAA: return DecodeType<T171>(byteArray, ref p);
                case 0xAB: return DecodeType<T172>(byteArray, ref p);
                case 0xAC: return DecodeType<T173>(byteArray, ref p);
                case 0xAD: return DecodeType<T174>(byteArray, ref p);
                case 0xAE: return DecodeType<T175>(byteArray, ref p);
                case 0xAF: return DecodeType<T176>(byteArray, ref p);
                case 0xB0: return DecodeType<T177>(byteArray, ref p);
                case 0xB1: return DecodeType<T178>(byteArray, ref p);
                case 0xB2: return DecodeType<T179>(byteArray, ref p);
                case 0xB3: return DecodeType<T180>(byteArray, ref p);
                case 0xB4: return DecodeType<T181>(byteArray, ref p);
                case 0xB5: return DecodeType<T182>(byteArray, ref p);
                case 0xB6: return DecodeType<T183>(byteArray, ref p);
                case 0xB7: return DecodeType<T184>(byteArray, ref p);
                case 0xB8: return DecodeType<T185>(byteArray, ref p);
                case 0xB9: return DecodeType<T186>(byteArray, ref p);
                case 0xBA: return DecodeType<T187>(byteArray, ref p);
                case 0xBB: return DecodeType<T188>(byteArray, ref p);
                case 0xBC: return DecodeType<T189>(byteArray, ref p);
                case 0xBD: return DecodeType<T190>(byteArray, ref p);
                case 0xBE: return DecodeType<T191>(byteArray, ref p);
                case 0xBF: return DecodeType<T192>(byteArray, ref p);
                case 0xC0: return DecodeType<T193>(byteArray, ref p);
                case 0xC1: return DecodeType<T194>(byteArray, ref p);
                case 0xC2: return DecodeType<T195>(byteArray, ref p);
                case 0xC3: return DecodeType<T196>(byteArray, ref p);
                case 0xC4: return DecodeType<T197>(byteArray, ref p);
                case 0xC5: return DecodeType<T198>(byteArray, ref p);
                case 0xC6: return DecodeType<T199>(byteArray, ref p);
                case 0xC7: return DecodeType<T200>(byteArray, ref p);
                case 0xC8: return DecodeType<T201>(byteArray, ref p);
                case 0xC9: return DecodeType<T202>(byteArray, ref p);
                case 0xCA: return DecodeType<T203>(byteArray, ref p);
                case 0xCB: return DecodeType<T204>(byteArray, ref p);
                case 0xCC: return DecodeType<T205>(byteArray, ref p);
                case 0xCD: return DecodeType<T206>(byteArray, ref p);
                case 0xCE: return DecodeType<T207>(byteArray, ref p);
                case 0xCF: return DecodeType<T208>(byteArray, ref p);
                case 0xD0: return DecodeType<T209>(byteArray, ref p);
                case 0xD1: return DecodeType<T210>(byteArray, ref p);
                case 0xD2: return DecodeType<T211>(byteArray, ref p);
                case 0xD3: return DecodeType<T212>(byteArray, ref p);
                case 0xD4: return DecodeType<T213>(byteArray, ref p);
                case 0xD5: return DecodeType<T214>(byteArray, ref p);
                case 0xD6: return DecodeType<T215>(byteArray, ref p);
                case 0xD7: return DecodeType<T216>(byteArray, ref p);
                case 0xD8: return DecodeType<T217>(byteArray, ref p);
                case 0xD9: return DecodeType<T218>(byteArray, ref p);
                case 0xDA: return DecodeType<T219>(byteArray, ref p);
                case 0xDB: return DecodeType<T220>(byteArray, ref p);
                case 0xDC: return DecodeType<T221>(byteArray, ref p);
                case 0xDD: return DecodeType<T222>(byteArray, ref p);
                case 0xDE: return DecodeType<T223>(byteArray, ref p);
                case 0xDF: return DecodeType<T224>(byteArray, ref p);
                case 0xE0: return DecodeType<T225>(byteArray, ref p);
                case 0xE1: return DecodeType<T226>(byteArray, ref p);
                case 0xE2: return DecodeType<T227>(byteArray, ref p);
                case 0xE3: return DecodeType<T228>(byteArray, ref p);
                case 0xE4: return DecodeType<T229>(byteArray, ref p);
                case 0xE5: return DecodeType<T230>(byteArray, ref p);
                case 0xE6: return DecodeType<T231>(byteArray, ref p);
                case 0xE7: return DecodeType<T232>(byteArray, ref p);
                case 0xE8: return DecodeType<T233>(byteArray, ref p);
                case 0xE9: return DecodeType<T234>(byteArray, ref p);
                case 0xEA: return DecodeType<T235>(byteArray, ref p);
                case 0xEB: return DecodeType<T236>(byteArray, ref p);
                case 0xEC: return DecodeType<T237>(byteArray, ref p);
                case 0xED: return DecodeType<T238>(byteArray, ref p);
                case 0xEE: return DecodeType<T239>(byteArray, ref p);
                case 0xEF: return DecodeType<T240>(byteArray, ref p);
                case 0xF0: return DecodeType<T241>(byteArray, ref p);
                case 0xF1: return DecodeType<T242>(byteArray, ref p);
                case 0xF2: return DecodeType<T243>(byteArray, ref p);
                case 0xF3: return DecodeType<T244>(byteArray, ref p);
                case 0xF4: return DecodeType<T245>(byteArray, ref p);
                case 0xF5: return DecodeType<T246>(byteArray, ref p);
                case 0xF6: return DecodeType<T247>(byteArray, ref p);
                case 0xF7: return DecodeType<T248>(byteArray, ref p);
                case 0xF8: return DecodeType<T249>(byteArray, ref p);
                case 0xF9: return DecodeType<T250>(byteArray, ref p);
                case 0xFA: return DecodeType<T251>(byteArray, ref p);
                case 0xFB: return DecodeType<T252>(byteArray, ref p);
                case 0xFC: return DecodeType<T253>(byteArray, ref p);
                case 0xFD: return DecodeType<T254>(byteArray, ref p);
                case 0xFE: return DecodeType<T255>(byteArray, ref p);
                case 0xFF: return DecodeType<T256>(byteArray, ref p);
                default:
                    return null;
            }
        }

        /// <summary>
        /// BaseEnumExt Create
        /// </summary>
        public void Create(T0 t, IType value2)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(Convert.ToByte(t));
            bytes.AddRange(value2.Encode());
            Bytes = bytes.ToArray();
            Value = t;
            Value2 = value2;
            TypeSize = Bytes.Length;
        }

        /// <inheritdoc/>
        public override string ToString() => JsonConvert.SerializeObject(Value);

        /// <summary>
        /// BaseEnumExt Enumeration Value
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public T0 Value { get; set; }

        /// <summary>
        /// BaseEnumExt Type Value
        /// </summary>
        public IType Value2 { get; set; }
    }

}