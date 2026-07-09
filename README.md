# Duarte-TGPSI24T
# Shion Gym Management System

## Descrição

O Shion Gym Management System é uma aplicação desenvolvida em C# (Windows Forms) com SQL Server para gerir um ginásio.

O sistema permite o registo e autenticação de utilizadores, aprovação de contas por um administrador, gestão de equipamentos, gestão de personal trainers e administração dos pedidos de registo.

---

## Funcionalidades

### Utilizadores

* Criar conta.
* Login.
* Alterar palavra-passe.
* Estado da conta (**Negado** ou **Aceite**).

### Administrador

* Login de administrador.
* Aceitar ou rejeitar pedidos de registo.
* Editar utilizadores.
* Remover utilizadores.
* Gerir equipamentos.
* Gerir personal trainers.

### Equipamentos

* Adicionar equipamentos.
* Remover equipamentos.
* Classificar equipamentos por tipo:

  * Cardio
  * Pernas
  * Polia
  * Braços
  * Peito
  * Costas

### Personal Trainers

* Adicionar personal trainers.
* Remover personal trainers.
* Consultar informações dos personal trainers:

  * Nome
  * Especialidade
  * Experiência
  * Formação
  * Contacto
  * Email

---

## Tecnologias utilizadas

* C#
* Windows Forms
* SQL Server LocalDB
* SQL Server Management Studio (SSMS)

---

## Base de dados

O projeto utiliza uma base de dados chamada ShionDB.

Tabelas existentes:

* utilizadores
* pedidos
* equipamentos
* personal_trainers

Também são utilizadas:

* Triggers para criação automática de pedidos.
* Trigger para sincronização do estado entre utilizadores e pedidos.
* Foreign Key com `ON DELETE CASCADE` para eliminar automaticamente os pedidos quando um utilizador é removido.

---

## Ligação à base de dados

String de ligação utilizada:

@"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;"

---

## Como executar

1. Abrir o SQL Server Management Studio.
2. Executar o script SQL para criar a base de dados **ShionDB**.
3. Abrir o projeto no Visual Studio.
4. Verificar se a string de ligação corresponde à instalação do SQL Server LocalDB.
5. Executar o projeto.

---

## Autor

Projeto desenvolvido por Duarte Sousa, o objetivo é fazer gestão de um ginásio utilizando C# e SQL Server.
