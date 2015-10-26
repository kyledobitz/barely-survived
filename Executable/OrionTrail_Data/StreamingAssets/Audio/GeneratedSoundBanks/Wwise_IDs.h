/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID ENGINE_START = 2862969430U;
        static const AkUniqueID ENGINE_STOP = 3509916502U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID STOP_TITLE = 2370690330U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace ENGINE
        {
            static const AkUniqueID GROUP = 268529915U;

            namespace STATE
            {
                static const AkUniqueID DRIFT = 2067748134U;
                static const AkUniqueID HIGH = 3550808449U;
                static const AkUniqueID LOW = 545371365U;
                static const AkUniqueID MED = 981339021U;
                static const AkUniqueID WARP = 1873893307U;
            } // namespace STATE
        } // namespace ENGINE

        namespace MUSIC_STATE
        {
            static const AkUniqueID GROUP = 3826569560U;

            namespace STATE
            {
                static const AkUniqueID DANGER = 4174463524U;
                static const AkUniqueID EVENT = 3161415855U;
                static const AkUniqueID NORMAL = 1160234136U;
                static const AkUniqueID START_MENU = 2977420043U;
            } // namespace STATE
        } // namespace MUSIC_STATE

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID SPEED = 640949982U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID TEST = 3157003241U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
        static const AkUniqueID MUSIC = 3991942870U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__
