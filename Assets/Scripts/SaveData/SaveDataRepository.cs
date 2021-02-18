﻿using System;
using System.Collections.Generic;
using System.IO;
using General;
using SaveData.Models;
using UnityEngine;

namespace SaveData
{
    public sealed class SaveDataRepository
    {
        public static SaveDataRepository Instance => lazy.Value;

        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.sv";
        private readonly string _path;

        private static readonly Lazy<SaveDataRepository> lazy =
            new Lazy<SaveDataRepository>(() => new SaveDataRepository());

        private SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(IEnumerable<InteractiveObject> bonuses)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var saveData = new SavedData();

            foreach (var bonus in bonuses)
            {
                saveData.bonuses.Add(new Bonus()
                {
                    Position = bonus.transform.localPosition,
                    IsEnabled = bonus.gameObject.activeInHierarchy,
                    Uid = bonus.Uid,
                });
            }

            _data.Save(saveData, Path.Combine(_path, _fileName));
        }

        public void Load(List<InteractiveObject> bonuses)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var savedData = _data.Load(file);

            foreach (var savedBonus in savedData.bonuses)
            {
                var bonus = bonuses.Find(item => item.Equals(savedBonus));
                if (bonus)
                {
                    bonus.gameObject.SetActive(savedBonus.IsEnabled);
                }
            }
        }
    }
}