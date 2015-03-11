#region License
// Copyright (c) 2013 Antonie Blom
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace Pencil.Gaming.Audio
{
    public enum ALCapability
    {
        Invalid = -1,
    }

    public enum ALListenerf
    {
        Gain = 0x100A,
        EfxMetersPerUnit = 0x20004,
    }

    public enum ALListener3f
    {
        Position = 0x1004,
        Velocity = 0x1006,
    }

    public enum ALListenerfv
    {
        Orientation = 0x100F,
    }

    public enum ALSourcef
    {
        ReferenceDistance = 0x1020,
        MaxDistance = 0x1023,
        RolloffFactor = 0x1021,
        Pitch = 0x1003,
        Gain = 0x100A,
        MinGain = 0x100D,
        MaxGain = 0x100E,
        ConeInnerAngle = 0x1001,
        ConeOuterAngle = 0x1002,
        ConeOuterGain = 0x1022,
        SecOffset = 0x1024,
        // AL_EXT_OFFSET extension.
        EfxAirAbsorptionFactor = 0x20007,
        EfxRoomRolloffFactor = 0x20008,
        EfxConeOuterGainHighFrequency = 0x20009,
    }

    public enum ALSource3f
    {
        Position = 0x1004,
        Velocity = 0x1006,
        Direction = 0x1005,
    }

    public enum ALSourceb
    {
        SourceRelative = 0x202,
        Looping = 0x1007,
        EfxDirectFilterGainHighFrequencyAuto = 0x2000A,
        EfxAuxiliarySendFilterGainAuto = 0x2000B,
        EfxAuxiliarySendFilterGainHighFrequencyAuto = 0x2000C,
    }

    public enum ALSourcei
    {
        ByteOffset = 0x1026,
        // AL_EXT_OFFSET extension.
        SampleOffset = 0x1025,
        // AL_EXT_OFFSET extension.
        Buffer = 0x1009,
        SourceType = 0x1027,
        EfxDirectFilter = 0x20005,
    }

    public enum ALSource3i
    {
        EfxAuxiliarySendFilter = 0x20006,
    }

    public enum ALGetSourcei
    {
        ByteOffset = 0x1026,
        SampleOffset = 0x1025,
        Buffer = 0x1009,
        SourceState = 0x1010,
        BuffersQueued = 0x1015,
        BuffersProcessed = 0x1016,
        SourceType = 0x1027,
    }

    public enum ALSourceState
    {
        Initial = 0x1011,
        Playing = 0x1012,
        Paused = 0x1013,
        Stopped = 0x1014,
    }

    public enum ALSourceType
    {
        Static = 0x1028,
        Streaming = 0x1029,
        Undetermined = 0x1030,
    }

    public enum ALFormat
    {
        Mono8 = 0x1100,
        Mono16 = 0x1101,
        Stereo8 = 0x1102,
        Stereo16 = 0x1103,
        MonoALawExt = 0x10016,
        StereoALawExt = 0x10017,
        MonoMuLawExt = 0x10014,
        StereoMuLawExt = 0x10015,
        VorbisExt = 0x10003,
        Mp3Ext = 0x10020,
        MonoIma4Ext = 0x1300,
        StereoIma4Ext = 0x1301,
        MonoFloat32Ext = 0x10010,
        StereoFloat32Ext = 0x10011,
        MonoDoubleExt = 0x10012,
        StereoDoubleExt = 0x10013,
        Multi51Chn16Ext = 0x120B,
        Multi51Chn32Ext = 0x120C,
        Multi51Chn8Ext = 0x120A,
        Multi61Chn16Ext = 0x120E,
        Multi61Chn32Ext = 0x120F,
        Multi61Chn8Ext = 0x120D,
        Multi71Chn16Ext = 0x1211,
        Multi71Chn32Ext = 0x1212,
        Multi71Chn8Ext = 0x1210,
        MultiQuad16Ext = 0x1205,
        MultiQuad32Ext = 0x1206,
        MultiQuad8Ext = 0x1204,
        MultiRear16Ext = 0x1208,
        MultiRear32Ext = 0x1209,
        MultiRear8Ext = 0x1207,
    }

    public enum ALGetBufferi
    {
        Frequency = 0x2001,
        Bits = 0x2002,
        Channels = 0x2003,
        Size = 0x2004,
    }

    public enum ALBufferState
    {
        Unused = 0x2010,
        Pending = 0x2011,
        Processed = 0x2012,
    }

    public enum ALError
    {
        NoError = 0,
        InvalidName = 0xA001,
        IllegalEnum = 0xA002,
        InvalidEnum = 0xA002,
        InvalidValue = 0xA003,
        IllegalCommand = 0xA004,
        InvalidOperation = 0xA004,
        OutOfMemory = 0xA005,
    }

    public enum ALGetString
    {
        Vendor = 0xB001,
        Version = 0xB002,
        Renderer = 0xB003,
        Extensions = 0xB004,
    }

    public enum ALGetFloat
    {
        DopplerFactor = 0xC000,
        DopplerVelocity = 0xC001,
        SpeedOfSound = 0xC003,
    }

    public enum ALGetInteger
    {
        DistanceModel = 0xD000,
    }

    public enum ALDistanceModel
    {
        None = 0,
        InverseDistance = 0xD001,
        InverseDistanceClamped = 0xD002,
        LinearDistance = 0xD003,
        LinearDistanceClamped = 0xD004,
        ExponentDistance = 0xD005,
        ExponentDistanceClamped = 0xD006,
    }

    public enum ALAuxiliaryi
    {
        EffectslotEffect = 0x0001,
        EffectslotAuxiliarySendAuto = 0x0003,
    }

    public enum ALAuxiliaryf
    {
        EffectslotGain = 0x0002,
    }


    public enum ALEffectf : int
    {
        ReverbDensity = 0x0001,
        ReverbDiffusion = 0x0002,
        ReverbGain = 0x0003,
        ReverbGainHF = 0x0004,
        ReverbDecayTime = 0x0005,
        ReverbDecayHFRatio = 0x0006,
        ReverbReflectionsGain = 0x0007,
        ReverbReflectionsDelay = 0x0008,
        ReverbLateReverbGain = 0x0009,
        ReverbLateReverbDelay = 0x000A,
        ReverbAirAbsorptionGainHF = 0x000B,
        ReverbRoomRolloffFactor = 0x000C,
        ChorusRate = 0x0003,
        ChorusDepth = 0x0004,
        ChorusFeedback = 0x0005,
        ChorusDelay = 0x0006,
        DistortionEdge = 0x0001,
        DistortionGain = 0x0002,
        DistortionLowpassCutoff = 0x0003,
        DistortionEQCenter = 0x0004,
        DistortionEQBandwidth = 0x0005,
        EchoDelay = 0x0001,
        EchoLRDelay = 0x0002,
        EchoDamping = 0x0003,
        EchoFeedback = 0x0004,
        EchoSpread = 0x0005,
        FlangerRate = 0x0003,
        FlangerDepth = 0x0004,
        FlangerFeedback = 0x0005,
        FlangerDelay = 0x0006,
        FrequencyShifterFrequency = 0x0001,
        VocalMorpherRate = 0x0006,
        RingModulatorFrequency = 0x0001,
        RingModulatorHighpassCutoff = 0x0002,
        AutowahAttackTime = 0x0001,
        AutowahReleaseTime = 0x0002,
        AutowahResonance = 0x0003,
        AutowahPeakGain = 0x0004,
        EqualizerLowGain = 0x0001,
        EqualizerLowCutoff = 0x0002,
        EqualizerMid1Gain = 0x0003,
        EqualizerMid1Center = 0x0004,
        EqualizerMid1Width = 0x0005,
        EqualizerMid2Gain = 0x0006,
        EqualizerMid2Center = 0x0007,
        EqualizerMid2Width = 0x0008,
        EqualizerHighGain = 0x0009,
        EqualizerHighCutoff = 0x000A,
        EaxReverbDensity = 0x0001,
        EaxReverbDiffusion = 0x0002,
        EaxReverbGain = 0x0003,
        EaxReverbGainHF = 0x0004,
        EaxReverbGainLF = 0x0005,
        EaxReverbDecayTime = 0x0006,
        EaxReverbDecayHFRatio = 0x0007,
        EaxReverbDecayLFRatio = 0x0008,
        EaxReverbReflectionsGain = 0x0009,
        EaxReverbReflectionsDelay = 0x000A,
        EaxReverbLateReverbGain = 0x000C,
        EaxReverbLateReverbDelay = 0x000D,
        EaxReverbEchoTime = 0x000F,
        EaxReverbEchoDepth = 0x0010,
        EaxReverbModulationTime = 0x0011,
        EaxReverbModulationDepth = 0x0012,
        EaxReverbAirAbsorptionGainHF = 0x0013,
        EaxReverbHFReference = 0x0014,
        EaxReverbLFReference = 0x0015,
        EaxReverbRoomRolloffFactor = 0x0016,
    }

    public enum ALEffect3f
    {
        EaxReverbLateReverbPan = 0x000E,
        EaxReverbReflectionsPan = 0x000B,
    }

    public enum ALEffecti
    {
        ChorusWaveform = 0x0001,
        ChorusPhase = 0x0002,
        FlangerWaveform = 0x0001,
        FlangerPhase = 0x0002,
        FrequencyShifterLeftDirection = 0x0002,
        FrequencyShifterRightDirection = 0x0003,
        VocalMorpherPhonemeA = 0x0001,
        VocalMorpherPhonemeACoarseTuning = 0x0002,
        VocalMorpherPhonemeB = 0x0003,
        VocalMorpherPhonemeBCoarseTuning = 0x0004,
        VocalMorpherWaveform = 0x0005,
        PitchShifterCoarseTune = 0x0001,
        PitchShifterFineTune = 0x0002,
        RingModulatorWaveform = 0x0003,
        CompressorOnoff = 0x0001,
        ReverbDecayHFLimit = 0x000D,
        EaxReverbDecayHFLimit = 0x0017,
    }

    public enum ALEffectType
    {
        EffectNull = 0x0000,
        EAXReverb = 0x8000,
        Reverb = 0x0001,
        Chorus = 0x0002,
        Distortion = 0x0003,
        Echo = 0x0004,
        Flanger = 0x0005,
        FrequencyShifter = 0x0006,
        VocalMorpher = 0x0007,
        PitchShifter = 0x0008,
        RingModulator = 0x0009,
        Autowah = 0x000A,
        Compressor = 0x000B,
        Equalizer = 0x000C,
    }

    public enum ALFilteri
    {
        //could be for later extensions
    }

    public enum ALFilterType
    {
        Null = 0x0000,
        Lowpass = 0x0001,
        Highpass = 0x0002,
        Bandpass = 0x0003,
    }

    public enum ALFilterf
    {
        LowpassGain = 0x0001,
        LowpassGainHF = 0x0002,
        HighpassGain = 0x0001,
        HighpassGainLF = 0x0002,
        BandpassGain = 0x0001,
        BandpassGainLF = 0x0002,
        BandpassGainHF = 0x0003,
    }
}
