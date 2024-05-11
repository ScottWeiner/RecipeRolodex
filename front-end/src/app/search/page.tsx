import { redirect } from "next/navigation"
import RecipesList from '@/components/recipes-list'
import Link from "next/link";
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
       
       
        <div className="drop-shadow-lg rounded bg-gray-200 h-full border p-2">
             <Link href='/'>Go back</Link>
             <p>Search Results Go Here!!</p>
        </div>
       
    )
}