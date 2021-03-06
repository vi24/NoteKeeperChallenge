﻿using System;

namespace NoteKeeperChallenge.Services
{
    public interface IStorageService
    {
        string FileExtensionName { get; }
        void SaveToFile(Object obj, string path, Type type);
        Object OpenFile(string path, Type type);
    }
}
