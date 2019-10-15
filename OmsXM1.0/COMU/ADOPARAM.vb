Public Module ADOPARAM
    Public Function ToString(ByVal value As String, Optional nom As String = "") As ADODB.Parameter
        ToString = New ADODB.Parameter

        With ToString
            .Type = ADODB.DataTypeEnum.adChar
            .Name = nom
            .Direction = ADODB.ParameterDirectionEnum.adParamInput
            If Len(value) = 0 Then
                .Size = 1
            Else
                .Size = Len(value)
            End If

            .Value = value
        End With
    End Function
    Public Function ToDate(ByVal value As Date, Optional nom As String = "") As ADODB.Parameter
        ToDate = New ADODB.Parameter
        With ToDate
            .Type = ADODB.DataTypeEnum.adDate
            .Name = nom
            .Direction = ADODB.ParameterDirectionEnum.adParamInput
            .Size = Len(value)
            .Value = value
        End With
    End Function
    Public Function ToInt(ByVal value As Integer, Optional nom As String = "") As ADODB.Parameter
        ToInt = New ADODB.Parameter
        With ToInt
            .Type = ADODB.DataTypeEnum.adInteger
            .Name = nom
            .Direction = ADODB.ParameterDirectionEnum.adParamInput
            .Size = Len(value)
            .Value = value
        End With
    End Function
    Public Function ToSingle(ByVal value As Integer, Optional nom As String = "") As ADODB.Parameter
        ToSingle = New ADODB.Parameter
        With ToSingle
            .Type = ADODB.DataTypeEnum.adSingle
            .Name = nom
            .Direction = ADODB.ParameterDirectionEnum.adParamInput
            .Size = Len(value)
            .Value = value
        End With
    End Function
    Public Function toBool(ByVal value As Boolean, Optional nom As String = "") As ADODB.Parameter
        toBool = New ADODB.Parameter
        With toBool
            .Type = ADODB.DataTypeEnum.adBoolean
            .Name = nom
            .Direction = ADODB.ParameterDirectionEnum.adParamInput
            .Size = Len(value)
            .Value = value
        End With
    End Function
End Module
