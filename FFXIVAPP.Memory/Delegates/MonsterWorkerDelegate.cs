﻿// FFXIVAPP.Memory ~ MonsterWorkerDelegate.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Concurrent;
using FFXIVAPP.Memory.Core;

namespace FFXIVAPP.Memory.Delegates
{
    internal static class MonsterWorkerDelegate
    {
        #region Collection Access & Modification

        public static void EnsureEntity(UInt32 key, ActorEntity entity)
        {
            EntitiesDictionary.AddOrUpdate(key, entity, (k, v) => entity);
        }

        public static ActorEntity GetEntity(UInt32 key)
        {
            ActorEntity entity;
            EntitiesDictionary.TryGetValue(key, out entity);
            return entity;
        }

        #endregion

        #region Declarations

        private static ConcurrentDictionary<UInt32, ActorEntity> _entitiesDictionary;

        public static ConcurrentDictionary<UInt32, ActorEntity> EntitiesDictionary
        {
            get { return _entitiesDictionary ?? (_entitiesDictionary = new ConcurrentDictionary<UInt32, ActorEntity>()); }
            set { _entitiesDictionary = value; }
        }

        #endregion
    }
}
