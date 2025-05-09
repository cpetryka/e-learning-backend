﻿using e_learning_backend.Domain.Classes.ValueObjects;

namespace e_learning_backend.Domain.Classes;


public class Class
{
    public  Guid Id { get; private set; }
    public DateTime StartTime { get; private set; }
    public string? Comment { get; private set; }
    public string? LinkToMeeting { get; private set; }
    public ClassStatus Status { get; private set; }
    public Class() { }
    public Class(
        Guid id, 
        DateTime startTime, 
        string? comment, 
        string? linkToMeeting, 
        ClassStatus status)
    {
        SetId(id);
        SetStartTime(startTime);
        SetComment(comment);
        SetLinkToMeeting(linkToMeeting);
        SetStatus(status);
    }

    public void SetStartTime(DateTime startTime)
    {
        if (startTime < DateTime.Now)
        {
            throw new ArgumentException("Start time cannot be in the past.");
        }
        StartTime = startTime;
    }
    public void SetComment(string? comment)
    {
        if (comment?.Length > 500)
            throw new ArgumentException("Comment is too long (max 500 characters).");
        Comment = comment;
    }
    
    public void SetLinkToMeeting(string? linkToMeeting)
    {
        LinkToMeeting = linkToMeeting;
    }
    
    public void SetStatus(ClassStatus status)
    {
        if (status == null) {
            throw new ArgumentNullException(nameof(status));
        }
        Status = status;
    }
    private void SetId(Guid id)
    {
        Id = id;
    }

}