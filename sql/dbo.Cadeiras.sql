CREATE TABLE [dbo].[Cadeiras] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [ETCS]      INT            NOT NULL,
    [Nome]      NVARCHAR (MAX) NOT NULL,
    [Concluida] BIT            NOT NULL,
    [Aluno_ID]  INT            NULL,
    CONSTRAINT [PK_dbo.Cadeiras] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.Cadeiras_dbo.Alunos_Aluno_ID] FOREIGN KEY ([Aluno_ID]) REFERENCES [dbo].[Alunos] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Aluno_ID]
    ON [dbo].[Cadeiras]([Aluno_ID] ASC);

