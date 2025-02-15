﻿using library_management_system.Exception;

namespace library_management_system.model;

public class Library
{
    public Dictionary<string, Publication> Publications { get; } = new();

    public Dictionary<string, LibraryUser> Users { get; } = new();

    public ICollection<Publication> GetSortedPublications(IComparer<Publication> comparer)
    {
        List<Publication> list = new List<Publication>(Publications.Values);
        list.Sort(comparer);
        return list;
    }

    public ICollection<LibraryUser> GetSortedUsers(IComparer<LibraryUser> comparator)
    {
        List<LibraryUser> list = new List<LibraryUser>(Users.Values);
        list.Sort(comparator);
        return list;
    }
    
    public void AddPublication (Publication publication) {
        if (Publications.ContainsKey(publication.Title)) {
            throw new PublicationAlreadyExistsException("Publikacja o takim tytule już istnieje " + publication.Title);
        }
        Publications.Add(publication.Title, publication);
    }

    public void AddUser(LibraryUser user) {
        if (Users.ContainsKey(user.Pesel)) {
            throw new UserAlreadyExistsException("Użytkownik ze wskazanym peselem już istnieje " + user.Pesel);
        }
        Users.Add(user.Pesel, user);
    }
    
    public bool RemovePublication(Publication pub)
    {
        if (!Publications.ContainsValue(pub)) return false;
        Publications.Remove(pub.Title);
        return true;
    }
}