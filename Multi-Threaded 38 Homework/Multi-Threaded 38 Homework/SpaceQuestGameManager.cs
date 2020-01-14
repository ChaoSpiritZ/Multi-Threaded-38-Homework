using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Threaded_38_Homework
{
    class SpaceQuestGameManager
    {
        private readonly int _GOOD_SPACE_SHIP_MAX_HIT_POINTS;
        private int _maxNumberOfBadShips;
        private int _goodSpaceShipHitPoints;
        private int _shipXLocation;
        private int _shipYLocation;
        private int _NumberOfBadShips;
        private int _currentLevel;
        public event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public event EventHandler<SpaceShipEventArgs> GameIsOver;

        public SpaceQuestGameManager(int goodSpaceShipHitPoints, int shipXLocation, int shipYLocation, int NumberOfBadShips)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _GOOD_SPACE_SHIP_MAX_HIT_POINTS = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _NumberOfBadShips = NumberOfBadShips;
            _maxNumberOfBadShips = NumberOfBadShips;
            _currentLevel = 1;
        }

        public void MoveSpaceShip(int newX, int newY)
        {
            _shipXLocation = newX;
            _shipYLocation = newY;

            OnGoodSpaceShipLocationChanged();
        }

        public void GoodSpaceShipGotDamaged(int damage)
        {
            _goodSpaceShipHitPoints -= damage;

            OnGoodSpaceShipHPChanged();

            if (_goodSpaceShipHitPoints <= 0)
            {
                OnGoodSpaceShipDestroyed();
            }
        }

        public void GoodSpaceShipGotExtraHP(int extra)
        {
            _goodSpaceShipHitPoints += extra;

            OnGoodSpaceShipHPChanged();
        }

        public void EnemyShipsDestroyed(int numberOfBadShipsDestroyed)
        {
            _NumberOfBadShips -= numberOfBadShipsDestroyed;

            OnBadShipsExploded(numberOfBadShipsDestroyed);

            if (_NumberOfBadShips <= 0)
            {
                _currentLevel += 1;
                OnLevelUpReached();
                if (_currentLevel >= 3)
                    OnGameOver();
                _goodSpaceShipHitPoints = _GOOD_SPACE_SHIP_MAX_HIT_POINTS;
                _maxNumberOfBadShips += 30;
                _NumberOfBadShips = _maxNumberOfBadShips;
            }
        }

        private void OnGameOver()
        {
            GameIsOver?.Invoke(this, new SpaceShipEventArgs() { LevelReached = _currentLevel, SpaceShipHP = _goodSpaceShipHitPoints });
        }

        private void OnGoodSpaceShipHPChanged()
        {
            GoodSpaceShipHPChanged?.Invoke(this, new PointsEventArgs { HitPoints = _goodSpaceShipHitPoints });
        }

        private void OnGoodSpaceShipLocationChanged()
        {
            GoodSpaceShipLocationChanged?.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
        }

        private void OnGoodSpaceShipDestroyed()
        {
            GoodSpaceShipDestroyed?.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
            OnGameOver();
        }

        private void OnBadShipsExploded(int numberOfExplodedBadShips)
        {
            BadShipsExploded?.Invoke(this, new BadShipsExplodedEventArgs { NumberOfExplodedBadShips = numberOfExplodedBadShips, NumberOfBadShipsAfterCasualties = _NumberOfBadShips });
        }

        private void OnLevelUpReached()
        {
            LevelUpReached?.Invoke(this, new LevelEventArgs { CurrentLevel = _currentLevel });
        }
    }
}
