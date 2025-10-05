Public Class RstCmbReporteExistenciaLote
    Private dsExistencia_Lotes As DataSet
    Private Rst_Lotes As ReporteExistenciaLote
    Private Args_lotes As ArgsReporteExistenciaLote


    Public Property DsExistenciaLotes As DataSet
        Get
            Return dsExistencia_Lotes
        End Get
        Set(value As DataSet)
            dsExistencia_Lotes = value
        End Set
    End Property

    Public Property RstLotes As ReporteExistenciaLote
        Get
            Return Rst_Lotes
        End Get
        Set(value As ReporteExistenciaLote)
            Rst_Lotes = value
        End Set
    End Property

    Public Property Argslotes As ArgsReporteExistenciaLote
        Get
            Return Args_lotes
        End Get
        Set(value As ArgsReporteExistenciaLote)
            Args_lotes = value
        End Set
    End Property
End Class
