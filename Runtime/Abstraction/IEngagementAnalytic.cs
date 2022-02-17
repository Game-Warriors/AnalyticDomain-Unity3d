namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IEngagementAnalytic
    {
        void InvideFriendClicked(string location);
        void FriendHelpClicked(string location);
        void RateUsClicked(string location);
        void ReferralUser();
        void FreeCoinsClick(string type);
        void VideoAdClick(string location);
        void WatchVideoAd(string location);
        void InviteClick(string location);
        void DailyReward(string type);
    }
}
