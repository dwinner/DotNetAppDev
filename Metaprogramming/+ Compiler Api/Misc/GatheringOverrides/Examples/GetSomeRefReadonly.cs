/*
    protected internal override ref readonly Manager GetSomeRefReadonly(out object param1, ref Manager manager)
    {
        return ref base.GetSomeRefReadonly(out param1, ref manager);
    }

*/

MethodDeclaration(
    RefType(
        IdentifierName(
            Identifier(
                TriviaList(),
                "Manager",
                TriviaList(
                    Space
                )
            )
        )
    )
    .WithRefKeyword(
        Token(
            TriviaList(),
            SyntaxKind.RefKeyword,
            TriviaList(
                Space
            )
        )
    )
    .WithReadOnlyKeyword(
        Token(
            TriviaList(),
            SyntaxKind.ReadOnlyKeyword,
            TriviaList(
                Space
            )
        )
    ),
    Identifier("GetSomeRefReadonly")
)
.WithModifiers(
    TokenList(
        new []{
            Token(
                TriviaList(
                    Whitespace("    ")
                ),
                SyntaxKind.ProtectedKeyword,
                TriviaList(
                    Space
                )
            ),
            Token(
                TriviaList(),
                SyntaxKind.InternalKeyword,
                TriviaList(
                    Space
                )
            ),
            Token(
                TriviaList(),
                SyntaxKind.OverrideKeyword,
                TriviaList(
                    Space
                )
            )
        }
    )
)
.WithParameterList(
    ParameterList(
        SeparatedList<ParameterSyntax>(
            new SyntaxNodeOrToken[]{
                Parameter(
                    Identifier("param1")
                )
                .WithModifiers(
                    TokenList(
                        Token(
                            TriviaList(),
                            SyntaxKind.OutKeyword,
                            TriviaList(
                                Space
                            )
                        )
                    )
                )
                .WithType(
                    PredefinedType(
                        Token(
                            TriviaList(),
                            SyntaxKind.ObjectKeyword,
                            TriviaList(
                                Space
                            )
                        )
                    )
                ),
                Token(
                    TriviaList(),
                    SyntaxKind.CommaToken,
                    TriviaList(
                        Space
                    )
                ),
                Parameter(
                    Identifier("manager")
                )
                .WithModifiers(
                    TokenList(
                        Token(
                            TriviaList(),
                            SyntaxKind.RefKeyword,
                            TriviaList(
                                Space
                            )
                        )
                    )
                )
                .WithType(
                    IdentifierName(
                        Identifier(
                            TriviaList(),
                            "Manager",
                            TriviaList(
                                Space
                            )
                        )
                    )
                )
            }
        )
    )
    .WithCloseParenToken(
        Token(
            TriviaList(),
            SyntaxKind.CloseParenToken,
            TriviaList(
                LineFeed
            )
        )
    )
)
.WithBody(
    Block(
        SingletonList<StatementSyntax>(
            ReturnStatement(
                RefExpression(
                    InvocationExpression(
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            BaseExpression(),
                            IdentifierName("GetSomeRefReadonly")
                        )
                    )
                    .WithArgumentList(
                        ArgumentList(
                            SeparatedList<ArgumentSyntax>(
                                new SyntaxNodeOrToken[]{
                                    Argument(
                                        IdentifierName("param1")
                                    )
                                    .WithRefKindKeyword(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.OutKeyword,
                                            TriviaList(
                                                Space
                                            )
                                        )
                                    ),
                                    Token(
                                        TriviaList(),
                                        SyntaxKind.CommaToken,
                                        TriviaList(
                                            Space
                                        )
                                    ),
                                    Argument(
                                        IdentifierName("manager")
                                    )
                                    .WithRefKindKeyword(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.RefKeyword,
                                            TriviaList(
                                                Space
                                            )
                                        )
                                    )
                                }
                            )
                        )
                    )
                )
                .WithRefKeyword(
                    Token(
                        TriviaList(),
                        SyntaxKind.RefKeyword,
                        TriviaList(
                            Space
                        )
                    )
                )
            )
            .WithReturnKeyword(
                Token(
                    TriviaList(
                        Whitespace("        ")
                    ),
                    SyntaxKind.ReturnKeyword,
                    TriviaList(
                        Space
                    )
                )
            )
            .WithSemicolonToken(
                Token(
                    TriviaList(),
                    SyntaxKind.SemicolonToken,
                    TriviaList(
                        LineFeed
                    )
                )
            )
        )
    )
    .WithOpenBraceToken(
        Token(
            TriviaList(
                Whitespace("    ")
            ),
            SyntaxKind.OpenBraceToken,
            TriviaList(
                LineFeed
            )
        )
    )
    .WithCloseBraceToken(
        Token(
            TriviaList(
                Whitespace("    ")
            ),
            SyntaxKind.CloseBraceToken,
            TriviaList(
                LineFeed
            )
        )
    )
)