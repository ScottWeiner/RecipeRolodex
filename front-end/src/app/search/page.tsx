import { redirect } from "next/navigation"
import RecipesList from '@/components/recipes-list'
//import { fetchPostsBySearchTerm } from "@/db/queries/posts";

interface SearchPageProps {
    searchParams: {
        term: string;
    }
}

export default async function SearchPage({ searchParams }: SearchPageProps) {
    const { term } = searchParams



    if (!term) {
        redirect('/')
    }

    return (
        <div>Search Page!</div>
    )
}