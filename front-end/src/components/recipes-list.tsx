import { fetchRecipeHeaders } from "@/actions";
import Link from "next/link";
import { Separator } from "./ui/Separator";

interface RecipeHeader {
    id: number;
    title: string;
    servings: number
}

export default async function RecipesList() {
    const recipes = await fetchRecipeHeaders()

    const renderedRecipes = recipes.map((rec: RecipeHeader) => {
        return (
            <>
                <div key={rec.id} className="p-2 m-1 bg-red-200">


                    <Link href={`recipes/${rec.id}`}>{rec.title}</Link>


                </div>
                <Separator className="bg-gray-400" />
            </>
        )
    })

    return (
        <>
            {renderedRecipes}
        </>
    )
}