                <div class="form-group">
                    <label class="control-label">{{PropertyName}}</label>
                    <input type="checkbox" name="{{PropertyName}}" class="form-control form-control-sm" value="true" @(Model.Notice.isPublic ? Html.Raw("checked=\"checked\"") : null) />
                </div>