using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }

        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");
        }

        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("LOCKED", "door locked");
        }

        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("UNLOCKED", "door unlocked");
        }

        public bool isClosed()
        {
            return this.door.isClosed();
        }

        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }

    interface OnDoorChanged
    {
        void onlockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}