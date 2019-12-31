                <div class="form-group">
                    <label for="{{PropertyName}}">{{PropertyName}}</label>
                    <select id="{{PropertyName}}" name="{{PropertyName}}" asp-items="ViewBag.{{PropertyName}}"
                            class="form-control form-control-sm" asp-for="@Model.{{Entity}}.{{PropertyName}}"></select>
                </div>