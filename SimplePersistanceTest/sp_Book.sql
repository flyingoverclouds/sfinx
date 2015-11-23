ALTER Procedure spS_titles

-- Retrieve specific records from the [titles] table depending on the input parameters you supply.

(
 @title_id [tid] = Null -- for [titles].[title_id] column
)

-- Returns the number of records found

As


		Select

		 [title_id]
		,[title]
		,[type]
		,[pub_id]
		,[price]
		,[advance]
		,[royalty]
		,[ytd_sales]
		,[notes]
		,[pubdate]

		From titles where title_id = @title_id
		
		Return(@@RowCount)

----------------------------------------------------------------------------------------------------------------------------------------------

ALTER Procedure spI_titles

-- Inserts a new record in [titles] table
(
  @title_id [tid] -- for [titles].[title_id] column
, @title [varchar](80) = Null  -- for [titles].[title] column
, @type [char](12) = Null  -- for [titles].[type] column
, @pub_id [char](4) = Null  -- for [titles].[pub_id] column
, @price [money] = Null  -- for [titles].[price] column
, @advance [money] = Null  -- for [titles].[advance] column
, @royalty [int] = Null  -- for [titles].[royalty] column
, @ytd_sales [int] = Null  -- for [titles].[ytd_sales] column
, @notes [varchar](200) = Null  -- for [titles].[notes] column
, @pubdate [datetime] = Null  -- for [titles].[pubdate] column
)

As

Set NoCount On

If @type Is Null
	Set @type = ('UNDECIDED')

If @pubdate Is Null
	Set @pubdate = (getdate())

Insert Into [dbo].[titles]
(
	  [title_id]
	, [title]
	, [type]
	, [pub_id]
	, [price]
	, [advance]
	, [royalty]
	, [ytd_sales]
	, [notes]
	, [pubdate]
)

Values
(
	  @title_id
	, @title
	, @type
	, @pub_id
	, @price
	, @advance
	, @royalty
	, @ytd_sales
	, @notes
	, @pubdate
)

Set NoCount Off

Return(0)

----------------------------------------------------------------------------------------------------------------------------------
ALTER Procedure spU_titles

-- Update an existing record in [titles] table

(
  @title_id [tid] -- for [titles].[title_id] column
, @title [varchar](80) -- for [titles].[title] column
, @type [char](12) -- for [titles].[type] column
, @pub_id [char](4) = Null -- for [titles].[pub_id] column
, @price [money] = Null -- for [titles].[price] column
, @advance [money] = Null -- for [titles].[advance] column
, @royalty [int] = Null -- for [titles].[royalty] column
, @ytd_sales [int] = Null -- for [titles].[ytd_sales] column
, @notes [varchar](200) = Null -- for [titles].[notes] column
, @pubdate [datetime] -- for [titles].[pubdate] column
)

As


Update [dbo].[titles]

Set
	[title] =  @title
	,[type] = @type
	,[pub_id] = @pub_id 
	,[price] =  @price 
	,[advance] = @advance 
	,[royalty] = @royalty 
	,[ytd_sales] = @ytd_sales 
	,[notes] = @notes 
	,[pubdate] =  @pubdate 

Where
	     ([title_id] = @title_id)

Return(0)

-----------------------------------------------------------------------------------------------------------------------------------
ALTER Procedure spD_titles

-- Delete a specific record from table [titles]

(
 @title_id [tid] -- for [titles].[title_id] column
,@pub_id [char](4) = Null -- for [titles].[pub_id] column
)

-- Returns the number of deleted records

As
Set NoCount On

Delete From [dbo].[titles]

Where
    ((@title_id Is Null) Or ([title_id] = @title_id))
And ((@pub_id Is Null) Or ([pub_id] = @pub_id))

Set NoCount Off

Return(@@RowCount)
