using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility
{

    public enum Gender : byte
    {
        Male = 1,
        Female
    }
    public enum Tab
    {
        College = 0,
        Facility,
        ClassRoomData,
        ClassRoomInfo
    }
    public enum AlertEnum : byte
    {
        Info,
        Success,
        Warning,
        Error,
    }

    public enum HTTPRequestType : byte
    {
        Get = 1,
        Post,
        Put,
        Delete
    }
    public enum ClassRoomCondition : byte
    {
        [Display(Name = "Good")]
        Good = 1,

        [Display(Name = "Needs Minor Repairs")]
        NeedsMinorRepairs,

        [Display(Name = "Needs Major Repairs")]
        NeedsMajorRepairs,

        [Display(Name = "Under Construction")]
        UnderConstruction,

        [Display(Name = "It's autumn")]
        Unusable
    }

    public enum Sponspor : byte
    {
        Government = 1,
        Community
    }

    public enum TeachingType : byte
    {
        [Display(Name = "Full Time")]
        Full = 1,

        [Display(Name = "Part Time")]
        Part,
    }
    public enum Postion : byte
    {
        [Display(Name = "Chairman")]
        Chairman = 1,

        [Display(Name = "Secretary ")]
        Secretary,

        [Display(Name = "Member")]
        Member,

    }
    public enum CPDFORMTYPE : byte
    {

        [Display(Name = "INSTRUMENT #1 ")]
        INSTRUMENT1 = 1,

        [Display(Name = "INSTRUMENT #2 ")]
        INSTRUMENT2 = 2,

        [Display(Name = "INSTRUMENT #3 ")]
        INSTRUMENT3 = 3,

        [Display(Name = "INSTRUMENT #4 ")]
        INSTRUMENT4 = 4,

        [Display(Name = "INSTRUMENT #5 ")]
        INSTRUMENT5 = 5,

        [Display(Name = "INSTRUMENT #6 ")]
        INSTRUMENT6 = 6,

        [Display(Name = "INSTRUMENT #7 ")]
        INSTRUMENT7 = 7,
    }
    public enum SourceOfIncome : byte
    {
        [Display(Name = "GOG")]
        GoG = 1,

        [Display(Name = "Donor")]
        Donor,
        [Display(Name = "SRC")]
        Src,
        [Display(Name = "College/Institution")]
        College,
        [Display(Name = "Others")]
        Other,
    }
    public enum FloorMaterial : byte
    {
        [Display(Name = "Mud Or Earth")]
        MudOrEarth = 1,

        [Display(Name = "Concrete")]
        Concrete,

        [Display(Name = "Wood")]
        Wood,

        [Display(Name = "Tile Or Terrazzo")]
        TileOrTerrazzo
    }

    public enum WallMaterial : byte
    {
        [Display(Name = "Mud")]
        Mud = 1,

        [Display(Name = "Cement Or Concrete")]
        CementOrConcrete,

        [Display(Name = "Wood Or Bamboo")]
        WoodOrBamboo,

        [Display(Name = "Burnt Bricks")]
        BurntBricks,

        [Display(Name = "Iron Sheets")]
        IronSheets,

        [Display(Name = "Stone")]
        Stone
    }

    public enum RoofMaterial : byte
    {
        [Display(Name = "Mud")]
        Mud = 1,

        [Display(Name = "Cement Or Concrete")]
        CementOrConcrete,

        [Display(Name = "Wood Or Bamboo")]
        WoodOrBamboo,

        [Display(Name = "Ceramic Tiles")]
        CeramicTiles,

        [Display(Name = "Iron Sheets")]
        IronSheets,

        [Display(Name = "Asbestos")]
        Asbestos
    }

    public enum SeatAvailability : byte
    {
        Yes = 1,
        No
    }

    public enum IsClassHeldOutside : byte
    {
        Yes = 1,
        No
    }

    public enum DisabilityAccessAvailability : byte
    {
        Yes = 1,
        No
    }

    public enum InputType
    {
        Text = 1,
        Number,
        Date,
        Checkbox,
        Option
    }

    public enum VariousContactList : byte
    {
        [Display(Name = "Principal")]
        Principal = 1,

        [Display(Name = "Vice Principal")]
        VicePrincipal,

        [Display(Name = "ICT System")]
        ICTSystem,

        [Display(Name = "Admin Officer")]
        AdminOfficer

    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public enum Semester : byte
    {
        [Display(Name = "First Semester")]
        FirstSemester = 1,

        [Display(Name = "Second Semester")]
        SecondSemester

    }

    public enum CourseOption : byte
    {
        [Display(Name = "Core")]
        Core = 1,

        [Display(Name = "Elective")]
        Elective

    }

    public enum DashBoardStatus
    {
        Increases = 1,
        Decrease,
        Equals
    }
    public enum CollegeModule
    {
        CollegeDetails = 1,
        facility,
        ClassRoomData,
        ClassRoomInfo,
        Programs,
        Courses,
    }

    public enum ProgramStatus : byte
    {
        Inactive = 1,
        Active
    }

    public enum Level
    {
        [Display(Name = "100")]
        HundredLevel = 100,
        [Display(Name = "200")]
        TwoHundredLevel = 200,
        [Display(Name = "300")]
        ThreeHundredLevel = 300,
        [Display(Name = "400")]
        FourHundredLevel = 400,
        [Display(Name = "500")]
        FiveHundredLevel = 500

    }

    public enum UserType : byte
    {
        Student = 1,
        Admin
    }




}
