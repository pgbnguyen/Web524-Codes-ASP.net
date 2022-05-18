
BEFORE running this app for the first time...

Add your own design model classes in the EntityModels Folder.

Follow these rules or conventions:
- To ease other coding tasks, the name of the integer identifier property should be "Id"
- Collection properties (including navigation properties) must be of type ICollection<T>
- Valid data annotations are pretty much limited to [Required] and [StringLength(n)]
- Required to-one navigation properties must include the [Required] attribute
- Do NOT configure scalar properties (e.g. int, double) with the [Required] attribute
- Initialize DateTime and collection properties in a default constructor

Then, add DbSet<TEntity> properties in the 
IdentityModels.cs source code file.
