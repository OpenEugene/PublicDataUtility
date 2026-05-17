
CREATE VIEW [lhb].[SubCategoryView]
AS
select AttributeId,ParentAttributeId as CategoryId, Name from [lhb].Attribute where ParentAttributeId is not null