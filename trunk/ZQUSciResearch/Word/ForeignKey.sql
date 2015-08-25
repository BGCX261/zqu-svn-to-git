
--�û���ɫ��Ӧ��sr_UserRole������FOREIGN KEYԼ��
ALTER TABLE sr_UserRole
ADD CONSTRAINT FK_UserRole_Roles
FOREIGN KEY(FK_RoleID)
REFERENCES sr_Roles(PK_RoleID)

ALTER TABLE sr_UserRole
ADD CONSTRAINT FK_UserRole_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(PK_UserID)


--��Ϣ��sr_Message������FOREIGN KEYԼ��
ALTER TABLE sr_Message
ADD CONSTRAINT FK_Message_Reciever
FOREIGN KEY(FK_RecieverID)
REFERENCES sr_User(PK_UserID)

ALTER TABLE sr_Message
ADD CONSTRAINT FK_Message_Sender
FOREIGN KEY(FK_SenderID)
REFERENCES sr_User(PK_UserID)



--����/����֪ͨ��sr_HelpNotice������FOREIGN KEYԼ��
ALTER TABLE sr_HelpNotice
ADD CONSTRAINT FK_HelpNotice_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(PK_UserID)


--���˿����ֱܷ�sr_TotalScore������FOREIGN KEYԼ��
ALTER TABLE sr_TotalScore
ADD CONSTRAINT FK_TotalScore_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--ѧ�����ı�/ѧ������/�̲ģ�sr_LwZzJc������FOREIGN KEYԼ��
ALTER TABLE sr_LwZzJc
ADD CONSTRAINT FK_LwZzJc_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--�ɹ����sr_Achievement������FOREIGN KEYԼ��
ALTER TABLE sr_Achievement
ADD CONSTRAINT FK_Achievement_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)


--��Ŀ���sr_Project������FOREIGN KEYԼ��
ALTER TABLE sr_Project
ADD CONSTRAINT FK_Project_User
FOREIGN KEY(FK_UserID)
REFERENCES sr_User(Pk_UserID)