
CREATE VIEW [lhb].[CategoryView]
AS
select AttributeId,Name from [lhb].Attribute where ParentAttributeId is null