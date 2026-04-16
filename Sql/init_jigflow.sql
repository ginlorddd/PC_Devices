/* JigFlow database initializer */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Roles')
BEGIN
    CREATE TABLE dbo.Roles
    (
        RoleCode VARCHAR(20) NOT NULL PRIMARY KEY,
        RoleName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(255) NULL,
        CreatedAt DATETIME NOT NULL DEFAULT(GETDATE())
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE dbo.Users
    (
        UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Username VARCHAR(50) NOT NULL UNIQUE,
        FullName NVARCHAR(200) NOT NULL,
        PasswordHash VARCHAR(32) NOT NULL,
        RoleCode VARCHAR(20) NOT NULL,
        Email VARCHAR(200) NULL,
        IsActive BIT NOT NULL DEFAULT(1),
        CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
        UpdatedAt DATETIME NULL,
        CONSTRAINT FK_Users_Roles FOREIGN KEY(RoleCode) REFERENCES dbo.Roles(RoleCode)
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Menus')
BEGIN
    CREATE TABLE dbo.Menus
    (
        MenuCode VARCHAR(50) NOT NULL PRIMARY KEY,
        MenuName NVARCHAR(200) NOT NULL,
        ParentCode VARCHAR(50) NULL,
        SortOrder INT NOT NULL DEFAULT(0),
        IsActive BIT NOT NULL DEFAULT(1)
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'RolePermissions')
BEGIN
    CREATE TABLE dbo.RolePermissions
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        RoleCode VARCHAR(20) NOT NULL,
        MenuCode VARCHAR(50) NOT NULL,
        CanView BIT NOT NULL DEFAULT(0),
        CanCreate BIT NOT NULL DEFAULT(0),
        CanEdit BIT NOT NULL DEFAULT(0),
        CanDelete BIT NOT NULL DEFAULT(0),
        CreatedAt DATETIME NOT NULL DEFAULT(GETDATE()),
        CONSTRAINT FK_RolePermissions_Roles FOREIGN KEY(RoleCode) REFERENCES dbo.Roles(RoleCode),
        CONSTRAINT FK_RolePermissions_Menus FOREIGN KEY(MenuCode) REFERENCES dbo.Menus(MenuCode),
        CONSTRAINT UQ_RolePermissions UNIQUE(RoleCode, MenuCode)
    );
END;

IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleCode = 'ADMIN')
    INSERT INTO dbo.Roles(RoleCode, RoleName, Description) VALUES ('ADMIN', N'Quản trị', N'Toàn quyền');

IF NOT EXISTS (SELECT 1 FROM dbo.Roles WHERE RoleCode = 'USER')
    INSERT INTO dbo.Roles(RoleCode, RoleName, Description) VALUES ('USER', N'Người dùng', N'Quyền cơ bản');

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
    INSERT INTO dbo.Users(Username, FullName, PasswordHash, RoleCode, Email, IsActive)
    VALUES ('admin', N'JigFlow Admin', 'e10adc3949ba59abbe56e057f20f883e', 'ADMIN', NULL, 1); -- 123456

IF NOT EXISTS (SELECT 1 FROM dbo.Menus WHERE MenuCode = 'JIG_LIST')
    INSERT INTO dbo.Menus(MenuCode, MenuName, ParentCode, SortOrder) VALUES ('JIG_LIST', N'Danh sách Jig', NULL, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.Menus WHERE MenuCode = 'USER_MGMT')
    INSERT INTO dbo.Menus(MenuCode, MenuName, ParentCode, SortOrder) VALUES ('USER_MGMT', N'Quản lý tài khoản', NULL, 2);

IF NOT EXISTS (SELECT 1 FROM dbo.Menus WHERE MenuCode = 'CHANGE_PASSWORD')
    INSERT INTO dbo.Menus(MenuCode, MenuName, ParentCode, SortOrder) VALUES ('CHANGE_PASSWORD', N'Đổi mật khẩu', NULL, 3);

IF NOT EXISTS (SELECT 1 FROM dbo.RolePermissions WHERE RoleCode = 'ADMIN' AND MenuCode = 'USER_MGMT')
    INSERT INTO dbo.RolePermissions(RoleCode, MenuCode, CanView, CanCreate, CanEdit, CanDelete)
    VALUES ('ADMIN', 'USER_MGMT', 1, 1, 1, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.RolePermissions WHERE RoleCode = 'ADMIN' AND MenuCode = 'JIG_LIST')
    INSERT INTO dbo.RolePermissions(RoleCode, MenuCode, CanView, CanCreate, CanEdit, CanDelete)
    VALUES ('ADMIN', 'JIG_LIST', 1, 1, 1, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.RolePermissions WHERE RoleCode = 'USER' AND MenuCode = 'JIG_LIST')
    INSERT INTO dbo.RolePermissions(RoleCode, MenuCode, CanView, CanCreate, CanEdit, CanDelete)
    VALUES ('USER', 'JIG_LIST', 1, 0, 0, 0);
