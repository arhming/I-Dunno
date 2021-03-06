﻿namespace KBEngine
{
    using UnityEngine;
    using System.Collections;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine.SceneManagement;

    public class Avatar : Entity
    {
        player _player;
        public player Player
        {
            get
            {
                if (_player == null && renderObj != null)
                    _player = ((GameObject)renderObj).GetComponent<player>();
                return _player;
            }
        }
        public int  Coin{ get {return (int)getDefinedProperty("Coin"); } }
        public List<object> Bag { get { return (List<object>)getDefinedProperty("Bag"); } }
        public void ReqUse(byte index)
        {
            baseCall("reqUse", index, Player.iso.Position);
        }
        protected override void __init__()
        {
            base.__init__();
            if (isPlayer())
            {
                SceneManager.LoadScene("Game");
                Event.registerIn("UpdatePlayer", this, "UpdatePlayer");
            }
        }
        internal void UpdatePlayer(Vector3 position)
        {
       
            this.position = position;
        }

    }
}