			context.CreatePermission("{{Permission}}.{{Entity}}",L("{{Permission}} {{Entity}}"))
				.CreateChildPermission("{{Permission}}.{{Entity}}.Create",L("{{Permission}} Create {{Entity}}"))
				.CreateChildPermission("{{Permission}}.{{Entity}}.Read",L("{{Permission}} Read {{Entity}}"))
				.CreateChildPermission("{{Permission}}.{{Entity}}.Update",L("{{Permission}} Update {{Entity}}"))
				.CreateChildPermission("{{Permission}}.{{Entity}}.Delete",L("{{Permission}} Delete {{Entity}}"));