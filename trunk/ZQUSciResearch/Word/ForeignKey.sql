
--用户角色对应表（sr_UserRole）创建FOREIGN KEY约束
ALTER TABLE sr_UserRole
ADD CONSTRAINT FK_UserRole_Roles
FOREIGN KEY(FK_RoleID)
REFERENCES sr_Roles(PK_RoleID)

ALTER TABLE sr_UserRole
ADD CONSTRAINT FK_UserRole_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(PK_UserID)


--消息表（sr_Message）创建FOREIGN KEY约束
ALTER TABLE sr_Message
ADD CONSTRAINT FK_Message_Reciever
FOREIGN KEY(FK_RecieverID)
REFERENCES sr_User(PK_UserID)

ALTER TABLE sr_Message
ADD CONSTRAINT FK_Message_Sender
FOREIGN KEY(FK_SenderID)
REFERENCES sr_User(PK_UserID)



--帮助/公告通知表（sr_HelpNotice）创建FOREIGN KEY约束
ALTER TABLE sr_HelpNotice
ADD CONSTRAINT FK_HelpNotice_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(PK_UserID)


--个人科研总分表（sr_TotalScore）创建FOREIGN KEY约束
ALTER TABLE sr_TotalScore
ADD CONSTRAINT FK_TotalScore_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--学术论文表/学术著作/教材（sr_LwZzJc）创建FOREIGN KEY约束
ALTER TABLE sr_LwZzJc
ADD CONSTRAINT FK_LwZzJc_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--成果类表（sr_Achievement）创建FOREIGN KEY约束
ALTER TABLE sr_Achievement
ADD CONSTRAINT FK_Achievement_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--项目类表（sr_Project）创建FOREIGN KEY约束
ALTER TABLE sr_Project
ADD CONSTRAINT FK_Project_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)