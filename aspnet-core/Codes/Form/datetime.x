                <div class="form-group">
                    <label for="{{PropertyName}}">{{PropertyName}}</label>
                    <input type="text" class="form-control form-control-sm js-datepicker"
                            id="{{PropertyName}}" name="{{PropertyName}}"
                            data-week-start="1" data-autoclose="true" data-today-highlight="true"
                            data-date-format="mm/dd/yyyy" placeholder="mm/dd/yyyy"
                            autocomplete="off"
			                value="@Model.{{Entity}}.{{PropertyName}}.ToString("yyyy-MM-ddThh:mm")" />
                </div>