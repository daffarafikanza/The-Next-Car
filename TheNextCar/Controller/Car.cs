using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }

        private bool doorIsClosed()
        {
            return this.doorController.isClosed();
        }

        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        private bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Close the door");
                return;
            }

            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }

            if (!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }

            this.callback.onCarEngineStateChanged("STOPED", "Engine Started");
        }

        public void toogleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toogleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }

        public void tooglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }

    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}