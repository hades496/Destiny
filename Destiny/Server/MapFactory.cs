﻿using Destiny.Game.Data;
using Destiny.Game.Maps;
using System.Collections.Generic;

namespace Destiny.Server
{
    public sealed class MapFactory : Dictionary<int, Map>
    {
        public byte World { get; private set; }
        public byte Channel { get; private set; }

        public new Map this[int mapleID]
        {
            get
            {
                if (!base.ContainsKey(mapleID))
                {
                    Map map = new Map(mapleID);

                    foreach (MapFootholdData foothold in map.Data.Footholds)
                    {

                    }

                    foreach(MapMobSpawnData mob in map.Data.Mobs)
                    {
                        map.Mobs.Add(new Mob(mob));
                    }

                    foreach(MapNpcSpawnData npc in map.Data.Npcs)
                    {
                        map.Npcs.Add(new Npc(npc));
                    }

                    base.Add(mapleID, map);
                }

                return base[mapleID];
            }
        }

        public MapFactory(byte world, byte channel)
            : base()
        {
            this.World = world;
            this.Channel = channel;
        }
    }
}