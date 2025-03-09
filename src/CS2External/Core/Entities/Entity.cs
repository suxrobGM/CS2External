using CS2External.Core.Game;
using CS2External.Utils;
using SharpDX;

namespace CS2External.Data.Entity;

public class Entity(int index) : EntityBase
{
    private int Index { get; } = index;

    private bool Dormant { get; set; } = true;

    protected internal bool IsSpotted { get; private set; }

    protected internal string Name { get; private set; } = null!;

    protected internal int IsinScope { get; private set; }

    protected internal int FlashAlpha { get; private set; }


    public Dictionary<string, Vector3> BonePos { get; } = new()
    {
        { "head", Vector3.Zero },
        { "neck_0", Vector3.Zero },
        { "spine_1", Vector3.Zero },
        { "spine_2", Vector3.Zero },
        { "pelvis", Vector3.Zero },
        { "arm_upper_L", Vector3.Zero },
        { "arm_lower_L", Vector3.Zero },
        { "hand_L", Vector3.Zero },
        { "arm_upper_R", Vector3.Zero },
        { "arm_lower_R", Vector3.Zero },
        { "hand_R", Vector3.Zero },
        { "leg_upper_L", Vector3.Zero },
        { "leg_lower_L", Vector3.Zero },
        { "ankle_L", Vector3.Zero },
        { "leg_upper_R", Vector3.Zero },
        { "leg_lower_R", Vector3.Zero },
        { "ankle_R", Vector3.Zero }
    };

    public override bool IsAlive()
    {
        return base.IsAlive() && !Dormant;
    }

    protected override IntPtr ReadControllerBase(GameProcess gameProcess)
    {
        var listEntryFirst = gameProcess.Process.Read<IntPtr>(EntityList + ((8 * (Index & 0x7FFF)) >> 9) + 16);
        return listEntryFirst == IntPtr.Zero
            ? IntPtr.Zero
            : gameProcess.Process.Read<IntPtr>(listEntryFirst + 120 * (Index & 0x1FF));
    }

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        var playerPawn = gameProcess.Process.Read<int>(ControllerBase + Offsets.m_hPawn);
        var listEntrySecond = gameProcess.Process.Read<IntPtr>(EntityList + 0x8 * ((playerPawn & 0x7FFF) >> 9) + 16);
        return listEntrySecond == IntPtr.Zero
            ? IntPtr.Zero
            : gameProcess.Process.Read<IntPtr>(listEntrySecond + 120 * (playerPawn & 0x1FF));
    }

    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess)) return false;

        Dormant = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_bDormant);
        IsSpotted = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_entitySpottedState + 0x8);
        IsinScope = gameProcess.Process.Read<int>(AddressBase + Offsets.m_bIsScoped);
        FlashAlpha = gameProcess.Process.Read<int>(AddressBase + Offsets.m_flFlashDuration);
        Name = gameProcess.Process.ReadString(ControllerBase + Offsets.m_iszPlayerName);
        if (!IsAlive()) return true;

        UpdateBonePos(gameProcess);

        return true;
    }

    private void UpdateBonePos(GameProcess gameProcess)
    {
        var gameSceneNode = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pGameSceneNode);
        var boneArray = gameProcess.Process.Read<IntPtr>(gameSceneNode + Offsets.m_modelState + 128);
        foreach (var (name, index) in Offsets.Bones)
        {
            var boneAddress = boneArray + index * 32;
            var bonePos = gameProcess.Process.Read<Vector3>(boneAddress);
            BonePos[name] = bonePos;
        }
    }
}