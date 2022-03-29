---
title: "Introduction"
weight: 1
# geekdocFlatSection: false
# geekdocToc: 6
# geekdocHidden: false
geekdocCollapseSection: true
---

## What is SchemaTypist? 

SchemaTypist is a simple developer toolkit that allows you to write type-safe database interactions in your .NET applications using Dapper and SqlKata.

## Why is this required?

If you use Dapper (with or without SqlKata) to interact with the database in your .NET application, you might have noticed there are a lot of ***magic strings*** - sql statements embedded within your code as strings.  This reduces the maintainability of your entire app.  Changes to your model have to be made in at least two places:  the database and those sql query strings.  Also, when mapping result sets back to objects, you might be using Dapper's default mechanism which infers mapping based on column names.  This is rather restrictive.  Alternatively, you might be using fluent mapping tools, but these again have to be maintained manually.

Both are examples of violations of the [DRY principle](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself).  

SchemaTypist eliminates this problem.  By fully leveraging the capabilities of Dapper and SqlKata (which is an excellent fluent SQL query builder), SchemaTypist allows developers to write type-safe database interactions, be they simple CRUD interactions or complex multi-step transactions. You only define your model once:  in the database.  SchemaTypist then generates the objects and the mapping, which seamlessly work with your database design.

## How does it work?

At its heart, SchemaTypist is a simple code generator.  It uses standard views to extract metadata about the defined database schema and generates entities and mappers for those database objects.  

SchemaTypist is extremely portable:  It generates .NETStandard2.0-compliant code, which means it can work with most .NET applications out there.  Additionally, the views used to extract metadata are within the INFORMATION_SCHEMA schema, which is enshrined within the SQL99 standard and supported by most modern RDBMS today.

## Where do I start?

Take look at the [Getting Started Guide](getting-started).